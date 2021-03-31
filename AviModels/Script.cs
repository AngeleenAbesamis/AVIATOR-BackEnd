using System;
using System.Collections.Generic;
using System.Text;

namespace AviModels
{
    public class Script
    {
        public int ID { get; set; }
        public int PilotID { get; set; }
        public string ScriptURL { get; set; }
        public User ScriptWriter { get; set; }
        public int ScriptWriterID { get; set; }
    }
}
