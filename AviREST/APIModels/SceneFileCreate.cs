using AviModels;
using System.ComponentModel.DataAnnotations;

namespace AviREST.APIModels
{
    public class SceneFileCreate
    {
        [Required]
        public int SceneID { get; set; }
        [Required]
        public int FileID { get; set; }
        public SceneFile ToDLModel()
        {
            return new SceneFile
            {
                SceneID = this.SceneID,
                FileID = this.FileID
            };
        }
    }
}
