using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OzelDersYerim.Entity.Concrete.Identity
{
    public class User : IdentityUser
    {

        public string ThisUserRole { get; set; }
        public Student Students { get; set; }
        public Teacher Teachers { get; set; }
       


    }
}