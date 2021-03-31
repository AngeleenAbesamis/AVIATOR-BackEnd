using System;
using System.Collections.Generic;
using System.Text;

namespace AviModels
{
    public class Contributor
    {
        public int ID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public Pilot Pilot { get; set; }
        public int PilotID { get; set; }
    }
}
