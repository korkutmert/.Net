using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Business.Concrete;
using OzelDersYerim.Core;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Web.Areas.Admin.Models.Dtos;

using System.Security.Cryptography.X509Certificates;

namespace OzelDersYerim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly IStudentService _studentManager;


        public StudentController(UserManager<User> userManager, IStudentService studentManager)
        {
            _userManager = userManager;
            _studentManager = studentManager;
        }


        public async Task<IActionResult> Index()
        {
            var students = await _studentManager.GetAllStudents();
            List<StudentListDto> studentListDtos = new List<StudentListDto>();
            foreach (var std in students)
            {
                studentListDtos.Add(new StudentListDto
                {
                    Id = std.User.Id,
                    UserName = std.User.UserName,
                    Email = std.User.Email,
                    FirstName = std.FirstName,
                    LastName = std.LastName,
                    DateOfBirth = std.DateOfBirth

                });

            }
            return View(studentListDtos);
        }

        public IActionResult CreateStudent()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentAddDto studentAddDto, string genderType)
        {
            if (genderType == "Man") { studentAddDto.Gender = "Erkek"; }
            if (genderType == "Woman") { studentAddDto.Gender = "Kadın"; }
            if (ModelState.IsValid)
            {
                var url = Jobs.InitUrl("ogrenci" + " " + studentAddDto.FirstName + " " + studentAddDto.LastName);
                var student = new Student
                {
                    FirstName = studentAddDto.FirstName,
                    LastName = studentAddDto.LastName,
                    Url = url,
                    DateOfBirth = studentAddDto.DateOfBirth,
                    Location = studentAddDto.Location,
                    Gender = studentAddDto.Gender,
                    User = new User

                    {
                        UserName = studentAddDto.UserName,
                        NormalizedUserName = studentAddDto.UserName.ToUpper(),
                        Email = studentAddDto.Email,
                        NormalizedEmail = studentAddDto.Email.ToUpper(),

                    }
                };
                await _studentManager.CreateStudent(student);
                return RedirectToAction("Index");
            }

            return View(studentAddDto);


        }

        public async Task<IActionResult> Edit(string id)
        {


            var onlyUserInfo = await _userManager.FindByIdAsync(id);
            var student = await _studentManager.GetStudentByUser(onlyUserInfo.UserName);
            if (student == null) { return NotFound(); }
            #region GENDER
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = student.Students.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = student.Students.Gender == "Erkek" ? true : false
            });

            #endregion
            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                Id = student.Id,
                UserName = student.UserName,
                Email = student.Email,
                FirstName = student.Students.FirstName,
                LastName = student.Students.LastName,
                DateOfBirth = student.Students.DateOfBirth,
                Gender = student.Students.Gender,
                GenderSelectList = genderList,
                Location=student.Students.Location,
                PhoneNumber=student.PhoneNumber

            };

            return View(userUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDto, string optionType)
        {
            if (ModelState.IsValid)
            {
                if (userUpdateDto == null) { return NotFound(); }

                var onlyUser = await _userManager.FindByIdAsync(userUpdateDto.Id);

                if (optionType == "Man") { userUpdateDto.Gender = "Erkek"; }
                else if (optionType == "Woman") { userUpdateDto.Gender = "Kadın"; }

                var user = await _studentManager.GetStudentByUser(onlyUser.UserName);
                user.Students.FirstName = userUpdateDto.FirstName;
                user.Students.LastName = userUpdateDto.LastName;
                user.UserName = userUpdateDto.UserName;
                user.Students.DateOfBirth = userUpdateDto.DateOfBirth;
                user.Students.Gender = userUpdateDto.Gender;
                user.Students.Location = userUpdateDto.Location;
                user.Email = userUpdateDto.Email;
                user.PhoneNumber=userUpdateDto.PhoneNumber;

                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(userUpdateDto);
        }
        public async Task<IActionResult> Delete(string id)
        {

            var student = await _studentManager.GetStudentByUser(id);
            if (student == null) { return NotFound(); }
            _studentManager.Delete(student.Students);
            await _userManager.DeleteAsync(student);
            return RedirectToAction("Index");
        }
    }
}
