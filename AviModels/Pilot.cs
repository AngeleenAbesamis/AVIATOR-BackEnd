using System;
using System.Collections.Generic;
using System.Text;

namespace AviModels
{
    public class Pilot
    {
        public int ID { get; set; }
        public User Producer { get; set; }
        public int ProducerID { get; set; }
        public string PilotName { get; set; }
        public string PilotDescription { get; set; }
        public Script Script { get; set; }
        public List<Scene> Scenes { get; set; }
        public List<File> Files { get; set; }
    }
}
