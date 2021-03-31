using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.APIModels
{
    public class FileDetails
    {
        public int ID { get; set; }
        public string FileURL { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public string ParsedID { get; set; }
        public UserMinimal Uploader { get; set; }
        public static FileDetails FromDLModel(File f)
        {
            if (f == null) return null;
            return new FileDetails { 
                ID = f.ID, 
                FileDescription = f.FileDescription, 
                FileName = f.FileName,
                FileURL = f.FileURL, 
                ParsedID = f.ParsedID, 
                Uploader = UserMinimal.FromDLModel(f.Uploader)
            };
        }
    }
}
