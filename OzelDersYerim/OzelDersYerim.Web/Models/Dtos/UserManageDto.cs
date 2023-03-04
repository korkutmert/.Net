using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersYerim.Entity.Concrete.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class UserManageDto
    {
        public string Id { get; set; }


        [DisplayName("Ad")]
        public string FirstName { get; set; }


        [DisplayName("Soyad")]
        public string LastName { get; set; }
       
        
        [DisplayName("Cinsiyet")]
        public string Gender { get; set; }

       
        
        [DisplayName("Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }



        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }

       
        
        [DisplayName("Hakkında")]
        public string About { get; set; }

      
        
        [DisplayName("Lokasyon")]
        public string Location { get; set; }

      
        
        [DisplayName("Saatlik Ücret")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]
        public decimal? PricePerHour { get; set; }

      
        
        [DisplayName("Tecrübe")]
        public string Experience { get; set; }

        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
       
        
        public List<SelectListItem> GenderSelectList { get; set; }

        
        
      
  



      
    }
}
