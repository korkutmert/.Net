using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class StudentDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
     
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]
        public string ProfilePictureUrl { get; set; }
    
        public string UserId { get; set; }
        public User User { get; set; }
        public List<StudentLesson> TeacherLessons { get; set; }
    }
}
