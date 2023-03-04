using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class TeacherLessonAddDto
    {
        [DisplayName("Kurs Adı")]
        public string LessonName { get; set; }
        
 [DisplayName("Kurs Açıklaması")]

        public string LessonDescription { get; set; }

        [DisplayName("Saatlik Ücret")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]
        public decimal LessonPricePerHour { get; set; }
        public string LessonUrl { get; set; }
        public string BranchName { get; set; }
        public TeacherLesson TeacherLesson { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string TeacherExperience { get; set; }
        public int SelectedBranchId { get; set; }
        [DisplayName("Branşlar")]
        public List<Branch> Branches { get; set; }
        public int TeacherId { get; set; }
        public string UserName { get; set; }
    }
}