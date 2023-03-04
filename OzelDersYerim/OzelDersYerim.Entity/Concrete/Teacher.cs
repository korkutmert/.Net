
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Entity.Concrete
{
    public class Teacher : BaseUserEntity
    {

       public string About { get; set; }
        public string Experience { get; set; }
        public string UserId { get; set; }
        public Decimal? PricePerHour { get; set; }
       public User User { get; set; }
        public bool IsHome { get; set; }
        public List<TeacherBranch> TeacherBranches { get; set; }
        public List<TeacherLesson> TeacherLessons { get; set; }
    }
}
