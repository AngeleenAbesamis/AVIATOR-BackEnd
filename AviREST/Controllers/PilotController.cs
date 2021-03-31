using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviREST.APIModels;
using AviBL;

namespace AviREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PilotController : ControllerBase
    {
        private IAviBL _aviBL;
        public PilotController(IAviBL aviBL)
        {
            _aviBL = aviBL;
        }
        [HttpGet]
        public IEnumerable<PilotListItem> Get([FromQuery] int? userID)
        {
            if (userID == null) return _aviBL.GetPilots().Select(pilot => PilotListItem.FromDLModel(pilot));
            return _aviBL.GetPilotsByProducerID((int)userID).Select(pilot => PilotListItem.FromDLModel(pilot));
        }
        [HttpGet]
        [Route("{id}")]
        public PilotDetails GetById(int id)
        {
            return PilotDetails.FromDLModel(_aviBL.GetPilotByID(id));
        }
        [HttpPost]
        public CreatedID Create(PilotCreate apiModel)
        {
            return new CreatedID { ID = _aviBL.AddPilot(apiModel.ToDLModel()).ID };
        }
    }
}
