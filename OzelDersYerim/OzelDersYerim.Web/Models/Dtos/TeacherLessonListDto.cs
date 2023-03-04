using OzelDersYerim.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class TeacherLessonListDto
    {
         public int Id { get; set; }

        [DisplayName("Kurs Adı")]
        public string Name { get; set; }

        [DisplayName("Kurs Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Saatlik Ücret")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]
        public decimal PricePerHour { get; set; }
        public string Url { get; set; }
        public int BranchId { get; set; }
        public int SelectedBranchId { get; set; }
        public List<Branch> Branches{ get; set; }

        public string TeacherFirstName { get; set; }
        public string TeacherLastName{ get; set; }
        public string TeacherExperience { get; set; }
        public int TeacherId { get; set; }

    }
}