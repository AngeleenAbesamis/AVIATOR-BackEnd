using AviBL;
using AviDL;
using AviModels;
using AviREST.APIModels;
using AviREST.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AviTests
{
    public class TestControllers
    {
        private Mock<IAviBL> _aviMock;

        public TestControllers()
        {
            _aviMock = new Mock<IAviBL>();
        }
        [Fact]
        public async Task GetShouldReturnPilotListItems()
        {
            var pilots = new List<Pilot> { new Pilot(),new Pilot() };
            _aviMock.Setup(x => x.GetPilots()).Returns(pilots);
            var newAviqtorBL = new PilotController(_aviMock.Object);
            var result = newAviqtorBL.Get(null);

            Assert.IsAssignableFrom<IEnumerable<PilotListItem>>(result);
            Assert.Equal(2,result.Count());
            _aviMock.Verify(x => x.GetPilots());
        }

        [Fact]
        public async Task GetByIdShouldReturnPilotDetails()
        {
            int pilotId = 1;
            var newPilot = new Pilot
            {
                ID = 1,
                Files = new List<File> { new File() },
                Scenes = new List<Scene> {
                    new Scene { SceneFiles = new List<SceneFile> { new SceneFile()} }
                },
                Script = new Script {
                    ScriptWriter = new User()
                }
            };
            _aviMock.Setup(x => x.GetPilotByID(It.IsAny<int>())).Returns(newPilot);
            var newAviqtorBL = new PilotController(_aviMock.Object);
            var result = newAviqtorBL.GetById(pilotId);

            Assert.IsAssignableFrom<PilotDetails>(result);
            Assert.Equal(result.ID, pilotId);
            _aviMock.Verify(x => x.GetPilotByID(pilotId));
        }

        [Fact]
        public async Task CreateShouldReturnCreatedID()
        {
            var newPilot = new Pilot { ID = 1 };
            var newPilotCreate = new PilotCreate { ProducerID = 1};
            _aviMock.Setup(x => x.AddPilot(It.IsAny<Pilot>())).Returns(newPilot);
            var newAviqtorBL = new PilotController(_aviMock.Object);
            var result = newAviqtorBL.Create(newPilotCreate);

            Assert.IsAssignableFrom<CreatedID>(result);
            Assert.Equal(result.ID,newPilotCreate.ProducerID);
            _aviMock.Verify(x => x.AddPilot(It.IsAny<Pilot>()));
        }
    }
}
