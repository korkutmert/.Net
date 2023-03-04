using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Core;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using OzelDersYerim.Web.Models.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace OzelDersYerim.Web.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly IBranchService _branchService;
        private readonly ILessonService _lessonService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherService, IStudentService studentService, IBranchService branchService , ILessonService lessonService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherService = teacherService;
            _studentService = studentService;
            _branchService = branchService;
            _lessonService = lessonService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto, string optionType,string genderType)
        {
            if(genderType=="Man"){registerDto.Gender="Erkek";}
            if(genderType=="Woman"){registerDto.Gender="Kadın";}

            if (optionType == "TeacherSelected")
            {

                if (ModelState.IsValid)
                {
                    var url=Jobs.InitUrl("ogretmen"+" "+registerDto.FirstName+" "+registerDto.LastName);
                    var user = new User
                    {

                        UserName = registerDto.UserName,
                        Email = registerDto.Email,
                        PhoneNumber=registerDto.PhoneNumber,
                        ThisUserRole = "Teacher",
                        
                         

                        Teachers = new Teacher
                        {
                            FirstName = registerDto.FirstName,
                            LastName = registerDto.LastName,
                            Url=url,
                            Gender=registerDto.Gender
                        }
                    };
                    var result = await _userManager.CreateAsync(user, registerDto.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Teacher");
                        return RedirectToAction("Index", "Home");

                    }
                }
                ModelState.AddModelError("", "Hata oluştu, lütfen tekrar deneyiniz.");
            }
            else if (optionType == "StudentSelected")
            {
                if (ModelState.IsValid)
                {
                var url = Jobs.InitUrl("ogrenci"+" "+registerDto.FirstName+" "+registerDto.LastName);

                    var user = new User
                    {
                        UserName = registerDto.UserName,
                        Email = registerDto.Email,
                        PhoneNumber=registerDto.PhoneNumber,
                        ThisUserRole = "Student",


                        Students = new Student
                        {
                            FirstName = registerDto.FirstName,
                            LastName = registerDto.LastName,
                            Url=url,
                            Gender=registerDto.Gender
                            
                        }
                    };
                    var result = await _userManager.CreateAsync(user, registerDto.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Student");
                        return RedirectToAction("Index", "Home");

                    }
                }
                ModelState.AddModelError("", "Hata oluştu, lütfen tekrar deneyiniz.");
                return View(registerDto);

            }

            return View(registerDto);
        }
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginDto { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(loginDto.Email);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
                        return View(loginDto);
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
                    if (result.Succeeded)
                    {
                        return Redirect(loginDto.ReturnUrl ?? "~/");
                    }
                    ModelState.AddModelError("", "Email adresi ya da parola hatalı!");
                }
                return View(loginDto);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public  async Task<IActionResult> Manage(string name)
        {
            if (String.IsNullOrEmpty(name)) { return NotFound(); }

            #region TEACHER
                if (User.IsInRole("Teacher"))
            {
                
                var userT =  await _teacherService.GetTeacherByUser(name);
                if (userT == null) { return NotFound(); }

                #region GENDER
                List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                 Text="Kadın",
                 Value="Kadın",
                 Selected=userT.Teachers.Gender=="Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected=userT.Teachers.Gender=="Erkek" ? true : false
            });
                    
                #endregion
                UserManageDto userManageDto = new UserManageDto
                {
                    Id = userT.Id,
                    UserName = userT.UserName,
                    Email = userT.Email,
                    FirstName = userT.Teachers.FirstName,
                    DateOfBirth = userT.Teachers.DateOfBirth,
                    Gender=userT.Teachers.Gender,
                    PricePerHour=userT.Teachers.PricePerHour,
                    LastName = userT.Teachers.LastName,
                    Experience = userT.Teachers.Experience,
                    About = userT.Teachers.About,
                    Location=userT.Teachers.Location,
                     GenderSelectList=genderList,
                     PhoneNumber=userT.PhoneNumber

                };
                return View(userManageDto);
            }
#endregion

            #region STUDENT
                else if(User.IsInRole("Student"))
            {
                
           var userS = await _studentService.GetStudentByUser(name);
          
             #region GENDER
                List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                 Text="Kadın",
                 Value="Kadın",
                 Selected=userS.Students.Gender=="Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected=userS.Students.Gender=="Erkek" ? true : false
            });
           #endregion
            if (userS==null) { return NotFound(); }
            UserManageDto userManageDto1 = new UserManageDto
            {
                Id=userS.Id,
                UserName=userS.UserName,
                Email = userS.Email,
                FirstName = userS.Students.FirstName,
                DateOfBirth = userS.Students.DateOfBirth,
                LastName = userS.Students.LastName,
                Gender=userS.Students.Gender,
                Location=userS.Students.Location,
                PhoneNumber=userS.PhoneNumber,
                GenderSelectList=genderList

            };
            #endregion
            return View(userManageDto1);
            }
            var admin= await _teacherService.GetTeacherByUser(name);
             UserManageDto userManageDto2=new UserManageDto{
                Id=admin.Id,
                UserName=admin.UserName,
                Email=admin.Email
             };
            return View(userManageDto2);

        }

        [HttpPost]
        public async Task<IActionResult> Manage(UserManageDto userManageDto)
        {
            if (userManageDto == null) { return NotFound(); }
           #region TEACHER
            
            if (User.IsInRole("Teacher"))
            
            {
                var ıdUser = await _userManager.FindByIdAsync(userManageDto.Id);
                var user = await _teacherService.GetTeacherByUser(ıdUser.UserName);
            

            if (user == null) { return NotFound(); }
                
                user.Teachers.FirstName = userManageDto.FirstName;
                user.Teachers.LastName = userManageDto.LastName;
                user.Teachers.DateOfBirth = userManageDto.DateOfBirth;
                user.Teachers.About = userManageDto.About;
                user.Teachers.Gender=userManageDto.Gender;
                user.Teachers.Experience = userManageDto.Experience;
                user.Teachers.PricePerHour=userManageDto.PricePerHour;
                user.UserName = userManageDto.UserName;
                user.Email = userManageDto.Email;
                 await _userManager.UpdateAsync(user);
               
                #region GENDER
                List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Teachers.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Teachers.Gender == "Erkek" ? true : false
            });
            userManageDto.GenderSelectList = genderList;   
                #endregion
                return View(userManageDto);
              
            }
           #endregion

           #region STUDENT
             else if (User.IsInRole("Student"))
            {
                var userId = await _userManager.FindByIdAsync(userManageDto.Id);
            var userS =await _studentService.GetStudentByUser(userId.UserName);
             

            if (userS==null) { return NotFound(); }

            userS.Students.FirstName = userManageDto.FirstName;
            userS.Students.LastName = userManageDto.LastName;
            userS.Students.DateOfBirth = userManageDto.DateOfBirth;
           
            userS.UserName = userManageDto.UserName;
            userS.Email = userManageDto.Email;
            userS.Students.Gender=userManageDto.Gender;
         await _userManager.UpdateAsync(userS);
              
                #region GENDER
                List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = userS.Students.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = userS.Students.Gender == "Erkek" ? true : false
            });
            userManageDto.GenderSelectList = genderList;   
            #endregion
            return View(userManageDto);
            }
           #endregion
            var admin= await _userManager.FindByIdAsync(userManageDto.Id);
            admin.UserName=userManageDto.UserName;
            admin.Email=userManageDto.Email;
            await _userManager.UpdateAsync(admin);
           
            return View(userManageDto);
        }

       






    }
}