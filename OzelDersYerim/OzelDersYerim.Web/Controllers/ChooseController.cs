using Microsoft.AspNetCore.Mvc;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Web.Models.Dtos;

namespace OzelDersYerim.Web.Controllers
{


    public class ChooseController : Controller
    {
        private readonly ITeacherService _teacherManager;
        private readonly IBranchService _branchManager;
        private readonly IStudentService _studentManager;

        public ChooseController(ITeacherService teacherManager, IBranchService branchManager, IStudentService studentManager)
        {
            _teacherManager = teacherManager;
            _branchManager = branchManager;
            _studentManager = studentManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TeacherList(string branchurl)
        {
            List<Teacher> teachers = await _teacherManager.GetBranchByTeacher(branchurl);
            List<TeacherDto> teacherDtos = new List<TeacherDto>();
            foreach (var teacher in teachers)
            {
                teacherDtos.Add(new TeacherDto
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    PricePerHour = teacher.PricePerHour,
                    DateOfBirth = teacher.DateOfBirth,
                    ProfilePictureUrl = teacher.ProfilePictureUrl,
                    Url = teacher.Url,
                    TeacherBranches = teacher.TeacherBranches
                });
            }
            return View(teacherDtos);
        }
        public async Task<IActionResult> TeacherDetails(string teacherUrl)
        {
            if (teacherUrl == null) { return NotFound(); }
            var teacher = await _teacherManager.GetTeacherDetailsByUrl(teacherUrl);
            TeacherDetailsDto teacherDetailsDto = new TeacherDetailsDto
            {
                Id = teacher.Id,
                FirstName=teacher.FirstName,
                LastName=teacher.LastName,
                UserId = teacher.UserId,
                About = teacher.About,
                Experience = teacher.Experience,
                PricePerHour = teacher.PricePerHour,
                ProfilePictureUrl=teacher.ProfilePictureUrl,
                TeacherBranches = teacher.TeacherBranches,
                TeacherLessons = teacher.TeacherLessons,
                PhoneNumber=teacher.User.PhoneNumber,
                Email=teacher.User.Email

            };
            return View(teacherDetailsDto);

        }
        public async Task<IActionResult> StudentDetails(string studentUrl)
        {
            if (studentUrl == null) { return NotFound(); }
            var student = await _studentManager.GetStudentDetailsByUrl(studentUrl);
            StudentDetailsDto studentDetailsDto = new StudentDetailsDto
            {
                Id = student.Id,
                FirstName=student.FirstName,
                LastName=student.LastName,
                UserId = student.UserId,             
                ProfilePictureUrl=student.ProfilePictureUrl,          
                TeacherLessons = student.StudentLessons,
                PhoneNumber=student.User.PhoneNumber,
                Email=student.User.Email,
                Location=student.Location

            };
            return View(studentDetailsDto);
        }
         public async Task <IActionResult> GetAllBranches()
        {
            var branch = await _branchManager.GetAllAsync();
            List<BranchAllDto> branchDtos = new List<BranchAllDto>();
            foreach (var item in branch)
            {
                branchDtos.Add(new BranchAllDto {
                    Id = item.Id,
                 BranchName =item.BranchName,
                 Url=item.Url,
                 ImageUrl=item.ImageUrl
                });
            }
            return View(branchDtos);
        }

      

        
    }
}
