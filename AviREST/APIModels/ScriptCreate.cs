using AviModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.APIModels
{
    public class ScriptCreate
    {
        [Required]
        public int PilotID { get; set; }
        [Required]
        public string ScriptBody { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public List<SceneCreate> Scenes { get; set; }
        internal string ScriptURL { get; set; }
        public Script ToDLModel()
        {
            return new Script
            {
                PilotID = this.PilotID,
                ScriptWriterID = this.UserID,
                ScriptURL = this.ScriptURL
            };
        }
    }
}
