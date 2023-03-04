using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OzelDersYerim.Web.Areas.Admin.Models.Dtos
{
    public class StudentAddDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }


        [DisplayName("Eposta")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DisplayName("Lokasyon")]
        public string Location { get; set; }

        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [DisplayName("Hakkında")]
        public string About { get; set; }


         [DisplayName("Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }


        [DisplayName("Cinsiyet")]     
        public string Gender { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }

         [DisplayName("Profil Fotoğrafı")]
    
        public IFormFile ImageFile { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
