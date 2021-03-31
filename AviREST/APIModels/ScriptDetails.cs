using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.APIModels
{
    public class ScriptDetails
    {
        public int ID { get; set; }
        public UserMinimal Scriptwriter { get; set; }
        public string ScriptURL { get; set; }
        public static ScriptDetails FromDLModel(Script s)
        {
            if (s == null) return null;
            return new ScriptDetails { ID = s.ID, ScriptURL = s.ScriptURL, Scriptwriter = UserMinimal.FromDLModel(s.ScriptWriter) };
        }
    }
}
