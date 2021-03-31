using AviBL;
using AviREST.APIModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;
using AviModels;

namespace AviREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScriptController : ControllerBase
    {
        private IAviBL _aviBL;
        private BlobServiceClient _blobSC;
        public ScriptController(IAviBL aviBL, BlobServiceClient blobSC)
        {
            _aviBL = aviBL;
            _blobSC = blobSC;
        }
        [HttpPost]
        public CreatedID Create(ScriptCreate apiModel)
        {
            string scriptURL = null;
            Script sc = _aviBL.GetScriptByPilotID(apiModel.PilotID);
            if (sc != null)
            {
                scriptURL = sc.ScriptURL;
                _aviBL.DeleteScriptIfExists(apiModel.PilotID);
            }
            _aviBL.DeleteScenesIfExists(apiModel.PilotID);
            foreach (SceneCreate sceneApiModel in apiModel.Scenes)
            {
                sceneApiModel.PilotID = apiModel.PilotID;
                _aviBL.AddScene(sceneApiModel.ToDLModel());
            }
            BlobContainerClient containerClient = _blobSC.GetBlobContainerClient($"pilot{apiModel.PilotID}");
            if (!containerClient.Exists())
            {
                containerClient = _blobSC.CreateBlobContainer($"pilot{apiModel.PilotID}", Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            }
            else if (scriptURL != null)
            {
                containerClient.DeleteBlob(scriptURL.Substring(scriptURL.LastIndexOf('/') + 1));
            }
            BlobClient blobClient = containerClient.GetBlobClient($"script{Guid.NewGuid().ToString()}.html");
            blobClient.Upload(GenerateStreamFromString(apiModel.ScriptBody));
            apiModel.ScriptURL = blobClient.Uri.AbsoluteUri;
            return new CreatedID { ID = _aviBL.AddScript(apiModel.ToDLModel()).ID };
        }
        private Stream GenerateStreamFromString(string str)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}