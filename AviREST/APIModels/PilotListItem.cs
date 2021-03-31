using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.APIModels
{
    public class PilotListItem
    {
        public int ID { get; set; }
        public int ProducerID { get; set; }
        public string PilotName { get; set; }
        public string PilotDescription { get; set; }
        public static PilotListItem FromDLModel(Pilot p)
        {
            if (p == null) return null;
            return new PilotListItem { 
                ID = p.ID,
                PilotName = p.PilotName,
                PilotDescription = p.PilotDescription,
                ProducerID = p.ProducerID
            };
        }
    }
}
