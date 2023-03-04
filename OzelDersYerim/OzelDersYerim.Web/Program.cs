using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Business.Concrete;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Data.Concrete.EfCore.Context;
using OzelDersYerim.Data.Concrete.EfCore.Repository;
using OzelDersYerim.Entity.Concrete.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OzelDersYerimContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<OzelDersYerimContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<OzelDersYerimContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<ILessonService, LessonManager>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "studentdetails",
//     pattern: "detaylar/{stundetUrl?}",
//     defaults: new { controller = "Choose", action = "StudentDetails" }
//     );
app.MapControllerRoute(
    name: "teacherdetails",
    pattern: "detaylar/{teacherhUrl?}",
    defaults: new { controller = "Choose", action = "TeacherDetails" }
    );
app.MapControllerRoute(
    name: "teachers",
    pattern: "branslar/{branchurl?}",
    defaults: new { controller = "Choose", action = "TeacherList" }
    );

app.MapAreaControllerRoute(
name: "Admin",
areaName: "Admin",
pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
