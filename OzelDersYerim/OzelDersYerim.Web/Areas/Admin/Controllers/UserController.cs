using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Web.Areas.Admin.Models.Dtos;

namespace OzelDersYerim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class UserController : Controller
    {
        private readonly ITeacherService _teacherManager;
        private readonly IStudentService _studentManager;



        public UserController(ITeacherService teacherManager, IStudentService studentManager)
        {
            _teacherManager = teacherManager;
            _studentManager = studentManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers =await _teacherManager.GetAllAsync();
            List<Student> students = await _studentManager.GetAllAsync();
            int teachersCount=teachers.Count();
            int studentsCount=students.Count();
            UserDto userDto =new UserDto{
                 TeachersCount=teachersCount,
                 StudentsCount=studentsCount
            };
             
             return View(userDto);
        }

        
    }
}