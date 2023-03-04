using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersYerim.Web.Areas.Admin.Models.Dtos
{
    public class StudentListDto
    {
        
        public string Id { get; set; }


        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string FirstName { get; set; }


        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }


        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }

        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DisplayName("Telefon Numarası")]  
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        
        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Lokasyon")]
        public string Location { get; set; }
   
         public string About { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Url { get; set; }
    }
}
