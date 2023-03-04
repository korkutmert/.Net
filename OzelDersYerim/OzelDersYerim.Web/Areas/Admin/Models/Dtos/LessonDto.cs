using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Areas.Admin.Models.Dtos
{
    public class AdminLessonDto
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string LessonDesc { get; set; }
        public decimal PricePerHour { get; set; }

        public List<StudentLesson> StudentLesson { get; set; }
        public List<TeacherLesson> TeacherLesson { get; set; }
        public int TeacherId { get; set; }
        public int StundetId { get; set; }
        public int TeacherLessonCount { get; set; }
        public int StudentLessonCount { get; set; }
        public int BranchId { get; set; }
        
    }
}