using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete.Identity;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class LessonDto
    {
        public int Id { get; set; }

        [DisplayName("Ders Adı")]
        public string Name { get; set; }

        [DisplayName("Ders Açıklaması")]       
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]
        [DisplayName("Saatlik Ücret")]
        public decimal PricePerHour { get; set; }
        public string Url { get; set; }
        public int BranchId { get; set; }
        
    }
}