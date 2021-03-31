using AviModels;
using AviREST.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AviTests
{
    public class TestModels
    {

        [Fact]
        public async Task FileDetails_FromDLModelShouldMapToFileDetails()
        {
            var newFile = new File { ID = 1, FileURL = "fileUrl", FileName = "filename", FileDescription = "description", ParsedID = "parsedId", Uploader = new User { ID = 1, UserName = "userMinimalName" }, Pilot = new Pilot {Files = new List<File>(), Script = new Script {ScriptWriter = new User()}}, SceneFiles = new List<SceneFile>() };
            var result = FileDetails.FromDLModel(newFile);
            Assert.Equal(result.ID, newFile.ID);
            Assert.Equal(result.FileURL, newFile.FileURL);
            Assert.Equal(result.FileName, newFile.FileName);
            Assert.Equal(result.FileDescription, newFile.FileDescription);
            Assert.Equal(result.ParsedID, newFile.ParsedID);
            Assert.Equal(result.Uploader.ID, newFile.Uploader.ID);
            Assert.Equal(result.Uploader.UserName, newFile.Uploader.UserName);
        }

        [Fact]
        public async Task PilotCreate_ToDLModelShouldMapToPilot()
        {
            var newPilotCreate = new PilotCreate { ProducerID = 1, PilotName = "name", PilotDescription = "description" };
            var result = newPilotCreate.ToDLModel();
            Assert.Equal(newPilotCreate.ProducerID, result.ProducerID);
            Assert.Equal(newPilotCreate.PilotName, result.PilotName);
            Assert.Equal(newPilotCreate.PilotDescription, result.PilotDescription);
        }

        [Fact]
        public async Task PilotDetails_ToDLModelShouldMapToPilotDetails()
        {
            var newPilot = new Pilot
            {
                ID = 1,
                PilotName = "name",
                Producer = new User { ID = 1, UserName = "userName" },
                PilotDescription = "description",
                Scenes = new List<Scene> { new Scene { SceneFiles = new List<SceneFile> { new SceneFile() } } },
                Files = new List<File> { new File { Uploader = new User() } },
                Script = new Script { ScriptWriter = new User() }
            };
            var result = PilotDetails.FromDLModel(newPilot);
            Assert.Equal(newPilot.ID, result.ID);
            Assert.Equal(newPilot.PilotName, result.PilotName);
            Assert.Equal(newPilot.PilotDescription, result.PilotDescription);
            Assert.Equal(newPilot.Producer.ID, result.Producer.ID);
            Assert.Equal(newPilot.Producer.UserName, result.Producer.UserName);
        }

        [Fact]
        public async Task PilotListItem_FromDLModelShouldMapToPilotListItem()
        {
            var newPilot = new Pilot
            {
                ID = 1,
                PilotName = "name",
                Producer = new User { ID = 1, UserName = "userName" },
                PilotDescription = "description",
            };
            var result = PilotListItem.FromDLModel(newPilot);
            Assert.Equal(newPilot.ID, result.ID);
            Assert.Equal(newPilot.PilotName, result.PilotName);
            Assert.Equal(newPilot.PilotDescription, result.PilotDescription);
        }

        [Fact]
        public async Task SceneCreate_ToDLModelShouldMapToScene()
        {
            var newSceneCreate = new SceneCreate
            {
                // PilotID = 1, // I can't test this because it's internal can use it out side the project
                SceneName = "sceneName",
                SceneDescription = "sceneDescription",
                SceneIndex = 1,
                ParsedID = "parsedId"
            };
            var result = newSceneCreate.ToDLModel();

            Assert.Equal(newSceneCreate.SceneName, result.SceneName);
            Assert.Equal(newSceneCreate.SceneDescription, result.SceneDescription);
            Assert.Equal(newSceneCreate.ParsedID, result.ParsedID);
            Assert.Equal(newSceneCreate.SceneIndex, result.SceneIndex);
        }

        [Fact]
        public async Task SceneDetails_FromDLModelShouldMapToSceneDetails()
        {
            var newScene = new Scene
            {
                ID = 1,
                SceneDescription = "sceneDescription",
                SceneName = "sceneName",
                SceneIndex = 1,
                ParsedID = "parsedId",
                SceneFiles = new List<SceneFile> { new SceneFile() }
            };
            var result = SceneDetails.FromDLModel(newScene);
            Assert.Equal(newScene.ID, result.ID);
            Assert.Equal(newScene.SceneDescription, result.SceneDescription);
            Assert.Equal(newScene.SceneName, result.SceneName);
            Assert.Equal(newScene.SceneIndex, result.SceneIndex);
            Assert.Equal(newScene.ParsedID, result.ParsedID);
        }

        [Fact]
        public async Task ScriptCreate_ToDLModelShouldMapToScript()
        {
            var newScriptCreate = new ScriptCreate
            {
                PilotID = 1,
                //ScriptURL = "ScriptURL", // I can't access this because it's internal
                UserID = 1,
            };
            var result = newScriptCreate.ToDLModel();

            Assert.Equal(newScriptCreate.PilotID, result.PilotID);
            Assert.Equal(newScriptCreate.UserID, result.ScriptWriterID);
        }
    }
}
