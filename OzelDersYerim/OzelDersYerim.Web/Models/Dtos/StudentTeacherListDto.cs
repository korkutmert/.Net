using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class StudentTeacherListDto
    {
        public List<StudentLesson> StudentLessons{ get; set; }
        public List<TeacherLesson> TeacherLessons { get; set; }
    }
}
