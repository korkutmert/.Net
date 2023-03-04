using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzelDersYerim.Business.Abstract;

using OzelDersYerim.Web.Areas.Admin.Models.Dtos;
using OzelDersYerim.Core;
using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OzelDersYerim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly ITeacherService _teacherManager;

        private readonly IBranchService _branchManager;

        public TeacherController(UserManager<User> userManager, ITeacherService teacherManager, IBranchService branchManager)
        {
            _userManager = userManager;

            _teacherManager = teacherManager;
            _branchManager = branchManager;
        }

        public async Task<IActionResult> Index()
        {

            var teachers = await _teacherManager.GetAllTeacher();

            List<TeacherListDto> teacherListDtos = new List<TeacherListDto>();

            foreach (var item in teachers)
            {
              
                teacherListDtos.Add(new TeacherListDto
                {
                    Id = item.User.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.User.UserName,
                    Email = item.User.Email,
                    DateOfBirth=item.DateOfBirth,
                    About=item.About,
                    Gender=item.Gender,
                    Location = item.Location,
                    Experience = item.Experience,
                    PricePerHour = item.PricePerHour

                });
            }
            return View(teacherListDtos);

        }
        [HttpGet]
        public async Task<IActionResult> CreateTeacher()
        {
            var branches = await _branchManager.GetAllAsync();
            var teacherAddDto = new TeacherAddDto
            {
                Branches = branches
            };
            return View(teacherAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherAddDto teacherAddDto,string genderType)
        {
            if(genderType=="Man"){teacherAddDto.Gender="Erkek";}
            if(genderType=="Woman"){teacherAddDto.Gender="Kadın";}
            if (ModelState.IsValid)
            {

                var url = Jobs.InitUrl("ogretmen"+" "+teacherAddDto.FirstName+" "+teacherAddDto.LastName);
                var teacher = new Teacher
                {
                    FirstName = teacherAddDto.FirstName,
                    LastName = teacherAddDto.LastName,
                    About = teacherAddDto.About,
                    Gender=teacherAddDto.Gender,
                    Url=url,
                    DateOfBirth = teacherAddDto.DateOfBirth,
                    Location = teacherAddDto.Location,
                    Experience = teacherAddDto.Experience,
                    PricePerHour = teacherAddDto.PricePerHour,
                    User = new User
                    {
                        UserName = teacherAddDto.UserName,
                        NormalizedUserName=teacherAddDto.UserName.ToUpper(),
                        Email = teacherAddDto.Email,
                        NormalizedEmail=teacherAddDto.Email.ToUpper(),


                    }
                };
                await _teacherManager.CreateTeacher(teacher, teacherAddDto.SelectedBranchIds);
                return RedirectToAction("Index");

            }
            var branches = await _branchManager.GetAllAsync();
            teacherAddDto.Branches = branches;

            return View(teacherAddDto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var onlyUserInfo = await _userManager.FindByIdAsync(id);
            var teacher = await _teacherManager.GetTeacherByUser(onlyUserInfo.UserName);
            if (teacher == null) { return NotFound(); }
             #region GENDER
                List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                 Text="Kadın",
                 Value="Kadın",
                 Selected=teacher.Teachers.Gender=="Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected=teacher.Teachers.Gender=="Erkek" ? true : false
            });
                    
                #endregion
            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                Id = teacher.Id,
                FirstName = teacher.Teachers.FirstName,
                LastName = teacher.Teachers.LastName,
                DateOfBirth = teacher.Teachers.DateOfBirth,
                Experience = teacher.Teachers.Experience,
                PricePerHour = teacher.Teachers.PricePerHour,
                About = teacher.Teachers.About,
                Gender = teacher.Teachers.Gender,
                Email = teacher.Email,
                PhoneNumber=teacher.PhoneNumber,
                UserName = teacher.UserName,
                Branches = await _branchManager.GetAllAsync(),
                GenderSelectList=genderList,
                SelectedBranchIds = teacher.Teachers.TeacherBranches.Select(tb => tb.BranchId).ToArray()
            };
            return View(userUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDto, int[] selectedBranchIds,string optionType)
        {
            if (ModelState.IsValid)
            {
                         if (optionType=="Man"){userUpdateDto.Gender="Erkek";  }
               else if (optionType=="Woman"){userUpdateDto.Gender="Kadın";}
                var onlyUserInfo = await _userManager.FindByIdAsync(userUpdateDto.Id);
                User teacher =  await _teacherManager.GetTeacherByUser(onlyUserInfo.UserName); if (teacher == null) { return NotFound(); }
                var url = Jobs.InitUrl(userUpdateDto.FirstName+userUpdateDto.LastName);
                teacher.Teachers.FirstName = userUpdateDto.FirstName;
                teacher.Teachers.LastName= userUpdateDto.LastName;
                 teacher.Teachers.DateOfBirth=userUpdateDto.DateOfBirth;
                teacher.Teachers.Experience=userUpdateDto.Experience;
                teacher.Teachers.About=userUpdateDto.About;
                teacher.Teachers.Gender=userUpdateDto.Gender;
                teacher.Teachers.PricePerHour=userUpdateDto.PricePerHour;
                teacher.Email=userUpdateDto.Email;
                teacher.PhoneNumber=userUpdateDto.PhoneNumber;
               teacher.UserName=userUpdateDto.UserName;
                teacher.Teachers.Url=url;
                await _teacherManager.UpdateTeacherAsync(teacher.Teachers, selectedBranchIds);
                return RedirectToAction("Index");
            }
            var branches=await _branchManager.GetAllAsync();
            userUpdateDto.Branches = branches;
            return View(userUpdateDto);
        }
   
        
          public async Task<IActionResult> Delete(string id)
        {
           var teacher = await _teacherManager.GetTeacherByUser(id);
            if(teacher == null) { return NotFound(); }
             _teacherManager.Delete(teacher.Teachers);
            await _userManager.DeleteAsync(teacher);
            return RedirectToAction("Index");
        }
    }
}