using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Web.Models.Dtos;

namespace OzelDersYerim.Web.Controllers;

public class HomeController : Controller
{

    private readonly ITeacherService _teacherService;
    private readonly ILessonService _lessonService;

    public HomeController(ITeacherService teacherService, ILessonService lessonService )
    {
        _teacherService = teacherService;
        _lessonService = lessonService;
    }

    // public async Task<IActionResult> Branch()
    // {
    //    List<Teacher> teachers = await _teacherService.GetHomePageTeachers();
    //    List<TeacherDto> teacherDtos = new List<TeacherDto>();
    //    foreach (var teacher in teachers)
    //    {
    //        teacherDtos.Add(new TeacherDto
    //        {
    //            Id = teacher.Id,
    //            FirstName = teacher.FirstName,
    //            LastName = teacher.LastName,
    //            DateOfBirth = teacher.DateOfBirth,
    //            Location = teacher.Location,
    //            PricePerHour = teacher.PricePerHour,
    //            Url = teacher.Url,
    //            ProfilePictureUrl = teacher.ProfilePictureUrl,
    //        });
    //    }
    //    return View(teacherDtos);
    // }
    public async Task<IActionResult> Index()
    {

        List<Lesson> lessons = await _lessonService.GetAllAsync();
        List<LessonDto> lessonDtos = new List<LessonDto>();
        foreach (var les in lessons)
        {
             lessonDtos.Add(new LessonDto{
                 Id=les.Id,
                 Name=les.Name,
                 Description=les.Description,
                 PricePerHour=les.PricePerHour,
                 Url=les.Url,
                 BranchId=les.BranchId,
                 

             });
        }
        return View(lessonDtos);

     

    }



}
