using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDersYerim.Entity.Concrete
{
    public class StudentLesson
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}