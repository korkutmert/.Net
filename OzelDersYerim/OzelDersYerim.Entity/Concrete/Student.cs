
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Entity.Concrete
{
    public class Student : BaseUserEntity
    {
        
       public string UserId { get; set; }
       public User User { get; set; }
       
       public List<StudentLesson> StudentLessons { get; set; }
       

    }
}
