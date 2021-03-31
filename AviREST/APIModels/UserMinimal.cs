using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.APIModels
{
    public class UserMinimal
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public static UserMinimal FromDLModel(User u)
        {
            if (u == null) return null;
            return new UserMinimal { 
                ID = u.ID, 
                UserName = u.UserName
            };
        }
    }
}
