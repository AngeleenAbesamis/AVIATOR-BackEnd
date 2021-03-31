using System;
using System.Collections.Generic;
using System.Text;

namespace AviModels
{
    public class SceneFile
    {
        public int ID { get; set; }
        public Scene Scene { get; set; }
        public int SceneID { get; set; }
        public File File { get; set; }
        public int FileID { get; set; }
    }
}
