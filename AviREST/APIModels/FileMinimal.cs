using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviModels;

namespace AviREST.APIModels
{
    public class FileMinimal
    {
        public int ID { get; set; }
        public string FileURL { get; set; }
        public string ParsedID { get; set; }
        public static FileMinimal FromDLModel(File f)
        {
            if (f == null) return null;
            return new FileMinimal
            {
                ID = f.ID,
                FileURL = f.FileURL,
                ParsedID = f.ParsedID
            };
        }
    }
}
