using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AviREST.APIModels
{
    public class PilotCreate
    {
        [Required]
        public int ProducerID { get; set; }
        [Required]
        public string PilotName { get; set; }
        [Required]
        public string PilotDescription { get; set; }
        public Pilot ToDLModel()
        {
            return new Pilot { ProducerID = this.ProducerID, PilotName = this.PilotName, PilotDescription = this.PilotDescription };
        }
    }
}
