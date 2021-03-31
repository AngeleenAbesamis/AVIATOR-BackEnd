using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviModels;

namespace AviREST.APIModels
{
    public class SceneDetails
    {
        public int ID { get; set; }
        public string SceneDescription { get; set; }
        public string SceneName { get; set; }
        public int SceneIndex { get; set; }
        public string ParsedID { get; set; }
        public List<FileDetails> Files { get; set; }
        public static SceneDetails FromDLModel(Scene s)
        {
            if (s == null) return null;
            return new SceneDetails {
                ID = s.ID,
                ParsedID = s.ParsedID,
                SceneDescription = s.SceneDescription,
                SceneIndex = s.SceneIndex,
                SceneName = s.SceneName,
                Files = s.SceneFiles.Select(sf => FileDetails.FromDLModel(sf.File)).ToList()
            };
        }
    }
}
