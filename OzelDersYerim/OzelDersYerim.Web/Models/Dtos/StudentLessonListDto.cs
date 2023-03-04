using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class StudentLessonListDto
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
        
       public string UserName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName{ get; set; }
        
    }
}