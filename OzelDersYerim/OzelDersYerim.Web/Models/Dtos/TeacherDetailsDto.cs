using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class TeacherDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string About { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Experience { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]

        public Decimal? PricePerHour { get; set; }
        public User User { get; set; }
        public List<TeacherBranch> TeacherBranches { get; set; }
        public List<TeacherLesson> TeacherLessons { get; set; }
    }
}
