using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Areas.Admin.Models.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
           
        public string FirstName { get; set; }

             
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int TeachersCount { get; set; }
        public int StudentsCount { get; set; }
        public Student Student { get; set; } 
        public Teacher Teacher { get; set; }
    }
}