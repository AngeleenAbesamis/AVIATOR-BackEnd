using AviModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AviREST.APIModels
{
    public class FileCreate
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PilotID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileDescription { get; set; }
        [Required]
        public string ParsedID { get; set; }
        [Required]
        public IFormFile File { get; set; }
        internal string FileURL { get; set; }
        public File ToDLModel()
        {
            return new File
            {
                PilotID = this.PilotID,
                UploaderID = this.UserID,
                FileURL = this.FileURL,
                FileName = this.FileName,
                FileDescription = this.FileDescription,
                ParsedID = this.ParsedID
            };
        }
    }
}
