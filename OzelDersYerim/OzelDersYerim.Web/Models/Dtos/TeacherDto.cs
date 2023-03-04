using System.ComponentModel.DataAnnotations;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Web.Models.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string ProfilePictureUrl { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:C}")]
        public Decimal? PricePerHour { get; set; }
        public int BranchId { get; set; }
        public List<TeacherBranch> TeacherBranches { get; set; }
    }
}
