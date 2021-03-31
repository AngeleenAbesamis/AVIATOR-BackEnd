using System;
using System.Collections.Generic;
using System.Text;

namespace AviModels
{
    public class Scene
    {
        public int ID { get; set; }
        public Pilot Pilot { get; set; }
        public int PilotID { get; set; }
        public int SceneIndex { get; set; } //For ordering scenes within pilot
        public string SceneName { get; set; }
        public string SceneDescription { get; set; }
        public string ParsedID { get; set; }
        public List<SceneFile> SceneFiles { get; set; }
    }
}
