using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.APIModels
{
    public class PilotDetails
    {
        public int ID { get; set; }
        public UserMinimal Producer { get; set; }
        public string PilotName { get; set; }
        public string PilotDescription { get; set; }
        public List<SceneDetails> Scenes { get; set; }
        public List<FileDetails> Files { get; set; }
        public ScriptDetails Script { get; set; }
        public static PilotDetails FromDLModel(Pilot p)
        {
            if (p == null) return null;
            return new PilotDetails {
                ID = p.ID,
                PilotName = p.PilotName,
                PilotDescription = p.PilotDescription,
                Producer = UserMinimal.FromDLModel(p.Producer),
                Files = p.Files.Select(f => FileDetails.FromDLModel(f)).ToList(),
                Scenes = p.Scenes.Select(s => SceneDetails.FromDLModel(s)).ToList(),
                Script = ScriptDetails.FromDLModel(p.Script)
            };
        }
    }
}
