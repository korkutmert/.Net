using Microsoft.AspNetCore.Mvc;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Core;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Web.Areas.Admin.Models.Dtos;
using OzelDersYerim.Web.Models.Dtos;

namespace OzelDersYerim.Web.Controllers
{

    

    public class TeacherLessonController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly ILessonService _lessonService;
        private readonly ITeacherService _teacherService;

        public TeacherLessonController(IBranchService branchService, ILessonService lessonService, ITeacherService teacherService)
        {
            _branchService = branchService;
            _lessonService = lessonService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GiveLesson(string name)
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
        public async Task<IActionResult> GiveLesson(TeacherLessonAddDto lessonAddDto)
        {
            var user = await _teacherService.GetTeacherByUser(lessonAddDto.UserName);
            var teacherId = user.Teachers.Id;
            var teacher = await _lessonService.GetTeacherWithLesson(teacherId);
            var teacherLesson = new TeacherLesson
            {
                Lesson = new Lesson
                {
                    Name = lessonAddDto.LessonName,
                    Description = lessonAddDto.LessonDescription,
                    PricePerHour = lessonAddDto.LessonPricePerHour,
                    Url = Jobs.InitUrl(lessonAddDto.LessonName),
                    BranchId = lessonAddDto.SelectedBranchId
                },
                TeacherId = teacher.Id,
                

            };
            teacher.TeacherLessons.Add(teacherLesson);
            _teacherService.Update(teacher);
            var branches = await _branchService.GetAllAsync();
            lessonAddDto.Branches = branches;
            return RedirectToAction("TeacherIndex", "TeacherLesson");

        }
        public async Task<IActionResult> TeacherIndex()
        {
            List<StudentLesson> studentLessons = await _lessonService.GetAllStudentLessons();
            List<StudentLessonListDto> studentLessonListDtos = new List<StudentLessonListDto>();
            foreach (var studLes in studentLessons)
            {
                studentLessonListDtos.Add(new StudentLessonListDto
                {
                    Id = studLes.LessonId,
                    Name = studLes.Lesson.Name,
                    Description = studLes.Lesson.Description,
                    PricePerHour = studLes.Lesson.PricePerHour,
                    StudentFirstName = studLes.Student.FirstName,
                    StudentLastName = studLes.Student.LastName


                });
            }
            return View(studentLessonListDtos);
        }

        public async Task<IActionResult> TeacherLessons(string username)
        {
                var teacherLessons= await _lessonService.GetTeacherLessonsByUserName(username);
            var teacherLessonsListDto = new List<TeacherLessonListDto> ();
            foreach (var tl in teacherLessons)
            {
                teacherLessonsListDto.Add(new TeacherLessonListDto { 
                Id=tl.LessonId,
                Name=tl.Lesson.Name,
                BranchId=tl.Lesson.BranchId,
                Description=tl.Lesson.Description,
                PricePerHour=tl.Lesson.PricePerHour
                });
                
            }
            return View(teacherLessonsListDto);
        }

        public async Task<IActionResult> EditTeacherLesson(int id)
        {
            var branches = await _branchService.GetAllAsync();
            var teacherLesson = await _lessonService.GetTeacherLessonByLessonId(id);
            var editTeacherLessonDto = new TeacherLessonListDto
            {
                Id=id,
                TeacherId=teacherLesson.TeacherId,
                Name=teacherLesson.Lesson.Name,
                Description=teacherLesson.Lesson.Description,
                PricePerHour=teacherLesson.Lesson.PricePerHour,
                BranchId = teacherLesson.Lesson.BranchId,
                Branches= branches,
                SelectedBranchId=teacherLesson.Lesson.BranchId
            };


            return View(editTeacherLessonDto);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeacherLesson(TeacherLessonListDto editTeacherLessonDto)
        {
            if (ModelState.IsValid)
            {
                var teacher = await _lessonService.GetTeacherWithLesson(editTeacherLessonDto.TeacherId);
                if (editTeacherLessonDto == null) { return NotFound(); }
                var teacherLesson = await _lessonService.GetTeacherLessonByLessonId(editTeacherLessonDto.Id);
                teacherLesson.Lesson.Name=editTeacherLessonDto.Name;
                teacherLesson.Lesson.Description=editTeacherLessonDto.Description;
                teacherLesson.Lesson.PricePerHour = editTeacherLessonDto.PricePerHour;
                teacherLesson.Lesson.BranchId = editTeacherLessonDto.SelectedBranchId;
                var teacherL = teacher.TeacherLessons.Where(tl => tl.LessonId == editTeacherLessonDto.Id).FirstOrDefault();
                teacherL = teacherLesson;
                _teacherService.Update(teacher);
            }
            var branches = await _branchService.GetAllAsync();
            editTeacherLessonDto.Branches = branches;
            return View(editTeacherLessonDto);
        }

        public async Task<IActionResult> DeleteTeacherLesson(int id)
        {
            var teacher = await _lessonService.GetTeacherByLessonId(id);
            
            var teacherLesson = await _lessonService.GetByIdAsync(id);
            _lessonService.Delete(teacherLesson);
            return Redirect("/TeacherLesson/TeacherLessons/"+teacher.User.UserName);
            //return RedirectToAction("Index", "Home");
        }

         public async Task<IActionResult> GetAllTeachers()
        {
              List<Teacher> teachers = await _teacherService.GetAllTeacher();
            var teacherListDto = new List<TeacherListDto>();
            foreach (var teacher in teachers)
            {
               teacherListDto.Add(new TeacherListDto{
                FirstName=teacher.FirstName,
                LastName=teacher.LastName,
                Email=teacher.User.Email,
                PhoneNumber=teacher.User.PhoneNumber,
                Location=teacher.Location,
                ProfilePictureUrl=teacher.ProfilePictureUrl,
                Url=teacher.Url,
                TeacherBranches = teacher.TeacherBranches,
              
                
               });
            }
            return View(teacherListDto);
            
        }
        
    }
}
