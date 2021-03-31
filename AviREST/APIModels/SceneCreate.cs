using AviModels;
using System.ComponentModel.DataAnnotations;

namespace AviREST.APIModels
{
    public class SceneCreate
    {
        [Required]
        public int SceneIndex { get; set; }
        [Required]
        public string SceneName { get; set; }
        [Required]
        public string SceneDescription { get; set; }
        [Required]
        public string ParsedID { get; set; }
        internal int PilotID { get; set; }
        public Scene ToDLModel()
        {
            return new Scene
            {
                PilotID = this.PilotID,
                SceneName = this.SceneName,
                SceneDescription = this.SceneDescription,
                SceneIndex = this.SceneIndex,
                ParsedID = this.ParsedID
            };
        }
    }
}