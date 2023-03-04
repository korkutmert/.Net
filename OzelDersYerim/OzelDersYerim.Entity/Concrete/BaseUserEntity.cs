using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDersYerim.Entity.Concrete
{
    public class BaseUserEntity
    {
          public int Id { get;  set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
       
       public string Location { get; set; }
       public string Url { get; set; }
       public string ProfilePictureUrl { get; set; }
    }
}