using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class StudentLessonAddDto
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
        public StudentLesson StudentLesson { get; set; }
        public string StudentFristName { get; set; }
        public string StudentLastName { get; set; }
        public int SelectedBranchId { get; set; }
        public List<Branch> Branches { get; set; }
        public int StudentId { get; set; }
        public string UserName { get; set; }
    }
}