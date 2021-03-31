using System;
using System.Collections.Generic;

namespace AviModels
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumb { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Contributor> Contributors { get; set; }
        public List<File> Files { get; set; }
        public List<Script> Scripts { get; set; }
    }
}
