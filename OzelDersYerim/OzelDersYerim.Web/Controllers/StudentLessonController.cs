using Microsoft.AspNetCore.Mvc;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Core;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Web.Models.Dtos;
using OzelDersYerim.Web.Areas.Admin.Models.Dtos;


namespace OzelDersYerim.Web.Controllers
{
    
    public class StudentLessonController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly ILessonService _lessonService;
        private readonly IStudentService _studentService;

        public StudentLessonController(IBranchService branchService, ILessonService lessonService, IStudentService studentService)
        {
            _branchService = branchService;
            _lessonService = lessonService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> TakeLesson(string name)
        {
            var branches = await _branchService.GetAllAsync();
            var lessonAddDto = new TeacherLessonAddDto
            {
                Branches = branches,
                UserName = name,
            };
            return View(lessonAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> TakeLesson(StudentLessonAddDto studentLessonAddDto)
        {
            var user = await _studentService.GetStudentByUser(studentLessonAddDto.UserName);
            var stundetId = user.Students.Id;
            var student = await _lessonService.GetStudentWithLesson(stundetId);
            var studentLesson = new StudentLesson
            {
                Lesson = new Lesson
                {
                    Name = studentLessonAddDto.LessonName,
                    Description = studentLessonAddDto.LessonDescription,
                    PricePerHour = studentLessonAddDto.LessonPricePerHour,
                    Url = Jobs.InitUrl(studentLessonAddDto.LessonName),
                    BranchId = studentLessonAddDto.SelectedBranchId,
                },
                StudentId = student.Id,

            };
            student.StudentLessons.Add(studentLesson);
            _studentService.Update(student);
            var branches = await _branchService.GetAllAsync();
            studentLessonAddDto.Branches = branches;
            return RedirectToAction("StudentIndex", "StudentLesson");

        }
        public async Task<IActionResult> StudentIndex()
        {
            List<TeacherLesson> teacherLessons = await _lessonService.GetAllTeacherLessons();
            List<TeacherLessonListDto> teacherLessonListDtos = new List<TeacherLessonListDto>();
            foreach (var teachLes in teacherLessons)
            {
                teacherLessonListDtos.Add(new TeacherLessonListDto
                {
                    Id = teachLes.LessonId,
                    Name = teachLes.Lesson.Name,
                    Description = teachLes.Lesson.Description,
                    PricePerHour = teachLes.Lesson.PricePerHour,
                    TeacherFirstName = teachLes.Teacher.FirstName,
                    TeacherLastName = teachLes.Teacher.LastName,
                    TeacherExperience = teachLes.Teacher.Experience,
                    Url=teachLes.Teacher.Url
                    


                });
            }
            return View(teacherLessonListDtos);
        }
         public async Task<IActionResult> StudentLessons(string username)
        {
                var studentLessons= await _lessonService.GetTeacherLessonsByUserName(username);
            var studentLessonListDto = new List<StudentLessonListDto> ();
            foreach (var tl in studentLessons)
            {
                studentLessonListDto.Add(new StudentLessonListDto { 
                Id=tl.LessonId,
                Name=tl.Lesson.Name,
                BranchId=tl.Lesson.BranchId,
                Description=tl.Lesson.Description,
                PricePerHour=tl.Lesson.PricePerHour
                });
                
            }
            return View(studentLessonListDto);
        }
        public async Task<IActionResult> GetAllStudents()
        {
              List<Student> students = await _studentService.GetAllStudents();
            var studentListDto = new List<StudentListDto>();
            foreach (var student in students)
            {
               studentListDto.Add(new StudentListDto{
               FirstName=student.FirstName,
               LastName=student.LastName,
               Email=student.User.Email,
               PhoneNumber=student.User.PhoneNumber,
               Url=student.Url
               });
            }
            return View(studentListDto);
            
        }
    }
}
