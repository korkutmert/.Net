using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Areas.Admin.Models.Dtos
{
    public class UserUpdateDto
    {
        public string Id { get; set; }

[DisplayName("Ad")]
        public string FirstName { get; set; }

[DisplayName("Soyad")]
    
        public string LastName { get; set; }
[DisplayName("Kullanıcı Adı")]

        public string UserName { get; set; }
[DisplayName("E-Posta")]
[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

[DisplayName("Telefon Numarası")]
[DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; }

[DisplayName("Hakkında")]

        public string About { get; set; }

[DisplayName("Doğum Tarihi")]

   
        public DateTime DateOfBirth { get; set; }

[DisplayName("Tecrübe")]

        public string Experience { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]

        public decimal? PricePerHour { get; set; }

[DisplayName("Lokasyon")]

        public string Location { get; set; }
[DisplayName("Cinsiyet")]

        public string Gender { get; set; }



        public IList<string> SelectedBranches { get; set; }
        public int[] SelectedBranchIds { get; set; }
[DisplayName("Branşlar")]

        public List<Branch> Branches { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
        
         [DisplayName("Profil Fotoğrafı")]
        
        public IFormFile ImageFile { get; set; }
        public string ProfilePictureUrl { get; set; }

    }
}
