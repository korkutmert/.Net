using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Web.Areas.Admin.Models.Dtos;
using OzelDersYerim.Web.Models.Dtos;

namespace OzelDersYerim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonController : Controller
    {
       private readonly ITeacherService _teacherManager;
       private readonly IStudentService _studentManager;
       private readonly ILessonService _lessonManager;
       private readonly IBranchService _branchManager;

        public LessonController(ITeacherService teacherManager, IStudentService studentManager, ILessonService lessonManager, IBranchService branchManager)
        {
            _teacherManager = teacherManager;
            _studentManager = studentManager;
            _lessonManager = lessonManager;
            _branchManager = branchManager;
        }

        public async Task<IActionResult> Index()
        {
             List<TeacherLesson> teacherLessons =await _lessonManager.GetAllTeacherLessons();
            List<StudentLesson> stundetLesson = await _lessonManager.GetAllStudentLessons();
            int teacherLesCount=teacherLessons.Count();
            int studentLesCount=stundetLesson.Count();
            AdminLessonDto adminLessonDto =new AdminLessonDto{
                 TeacherLessonCount=teacherLesCount,
                 StudentLessonCount=studentLesCount
            };
             
             return View(adminLessonDto);
        }

    public async Task<IActionResult> StudentLesson()
    {
           List<StudentLesson> studentLessons = await _lessonManager.GetAllStudentLessons();
            List<StudentLessonListDto> studentLessonListDtos = new List<StudentLessonListDto>();
            foreach (var studLes in studentLessons)
            {
                studentLessonListDtos.Add(new StudentLessonListDto
                {
                    Id = studLes.LessonId,
                    UserName=studLes.Student.User.UserName,
                    Name = studLes.Lesson.Name,
                    Description = studLes.Lesson.Description,
                    PricePerHour = studLes.Lesson.PricePerHour,
                    StudentFirstName = studLes.Student.FirstName,
                    StudentLastName = studLes.Student.LastName,
                    BranchId=studLes.Lesson.BranchId
                    


                });
            }
            return View(studentLessonListDtos);
    }

    public async Task<IActionResult> TeacherLesson()
    {
  var teacherLessons= await _lessonManager.GetAllTeacherLessons();
            var teacherLessonsListDto = new List<TeacherLessonListDto> ();
            foreach (var tl in teacherLessons)
            {
                teacherLessonsListDto.Add(new TeacherLessonListDto { 
                Id=tl.LessonId,
                Name=tl.Lesson.Name,
                TeacherFirstName=tl.Teacher.FirstName,
                TeacherLastName=tl.Teacher.LastName,
                BranchId=tl.Lesson.BranchId,
                Description=tl.Lesson.Description,
                PricePerHour=tl.Lesson.PricePerHour
                });
                
            }
            return View(teacherLessonsListDto);
    }
     public async Task<IActionResult> EditTeacherLesson(int id)
        {
            var branches = await _branchManager.GetAllAsync();
            var teacherLesson = await _lessonManager.GetTeacherLessonByLessonId(id);
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
                var teacher = await _lessonManager.GetTeacherWithLesson(editTeacherLessonDto.TeacherId);
                if (editTeacherLessonDto == null) { return NotFound(); }
                var teacherLesson = await _lessonManager.GetTeacherLessonByLessonId(editTeacherLessonDto.Id);
                teacherLesson.Lesson.Name=editTeacherLessonDto.Name;
                teacherLesson.Lesson.Description=editTeacherLessonDto.Description;
                teacherLesson.Lesson.PricePerHour = editTeacherLessonDto.PricePerHour;
                teacherLesson.Lesson.BranchId = editTeacherLessonDto.SelectedBranchId;
                var teacherL = teacher.TeacherLessons.Where(tl => tl.LessonId == editTeacherLessonDto.Id).FirstOrDefault();
                teacherL = teacherLesson;
                _teacherManager.Update(teacher);
            }
            var branches = await _branchManager.GetAllAsync();
            editTeacherLessonDto.Branches = branches;
            return View(editTeacherLessonDto);
        }

        public async Task<IActionResult> DeleteTeacherLesson(int id)
        {
            var teacher = await _lessonManager.GetTeacherByLessonId(id);
            
            var teacherLesson = await _lessonManager.GetByIdAsync(id);
            _lessonManager.Delete(teacherLesson);
            return Redirect("/TeacherLesson/TeacherLessons/"+teacher.User.UserName);
            //return RedirectToAction("Index", "Home");
        }
        
    }
}