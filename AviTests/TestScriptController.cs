using AviBL;
using AviModels;
using AviREST.APIModels;
using AviREST.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Xunit;

namespace AviTests
{
    public class TestScriptController
    {
        private Mock<IAviBL> _aviMock;
        private BlobServiceClient _blobSC;
        public TestScriptController()
        {
            _aviMock = new Mock<IAviBL>();
            _blobSC = new BlobServiceClient("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;");
            foreach (var c in _blobSC.GetBlobContainers())
            {
                _blobSC.DeleteBlobContainer(c.Name);
            }
        }

        [Fact]
        public async Task CreateShouldReturnCreatedID()
        {
            var newScene = new Scene() { ID = 1};
            var newScript = new Script() { ID = 1 };
            var newScriptCreate = new ScriptCreate { PilotID = 1,
                Scenes = new List<SceneCreate> { new SceneCreate()}
            };
            _aviMock.Setup(x => x.AddScene(It.IsAny<Scene>())).Returns(newScene);
            _aviMock.Setup(x => x.AddScript(It.IsAny<Script>())).Returns(newScript);

            var newAviqtorBL = new ScriptController(_aviMock.Object, _blobSC);
            var result = newAviqtorBL.Create(newScriptCreate);

            Assert.IsAssignableFrom<CreatedID>(result);
            Assert.Equal(result.ID, newScriptCreate.PilotID);
            _aviMock.Verify(x => x.AddScene(It.IsAny<Scene>()));
        }
    }
}
