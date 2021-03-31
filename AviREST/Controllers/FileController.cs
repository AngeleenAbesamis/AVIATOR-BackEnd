using AviBL;
using AviREST.APIModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;

namespace AviREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private IAviBL _aviBL;
        private BlobServiceClient _blobSC;
        public FileController(IAviBL aviBL, BlobServiceClient blobSC)
        {
            _aviBL = aviBL;
            _blobSC = blobSC;
        }
        [HttpPost]
        [ProducesResponseType(typeof(FileMinimal), 200)]
        public IActionResult Create([FromForm] FileCreate apiModel)
        {
            BlobContainerClient containerClient = _blobSC.GetBlobContainerClient($"pilot{apiModel.PilotID}");
            if (!containerClient.Exists())
            {
                containerClient = _blobSC.CreateBlobContainer($"pilot{apiModel.PilotID}", Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            }
            BlobClient blobClient = containerClient.GetBlobClient(apiModel.FileName);
            if (blobClient.Exists())
            {
                return BadRequest(new { error = "File name already taken for this pilot" });
            }
            blobClient.Upload(apiModel.File.OpenReadStream());
            apiModel.FileURL = blobClient.Uri.AbsoluteUri;
            return Ok(FileMinimal.FromDLModel(_aviBL.AddFile(apiModel.ToDLModel())));
        }
        [HttpPost]
        [Route("/SceneFile")]
        public CreatedID CreateSceneFile(SceneFileCreate apiModel)
        {
            return new CreatedID { ID = _aviBL.AddSceneFile(apiModel.ToDLModel()).ID };
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