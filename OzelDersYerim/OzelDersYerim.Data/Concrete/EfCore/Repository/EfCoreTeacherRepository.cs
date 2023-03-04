using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Data.Concrete.EfCore.Context;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Concrete.EfCore.Repository
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(OzelDersYerimContext context) : base(context)
        {
        }

        private OzelDersYerimContext OzelDersYerimContext
        {
            get { return _context as OzelDersYerimContext; }
        }

        public async Task CreateTeacher(Teacher teacher, int[] selectedBranchIds)
        {
            await OzelDersYerimContext.Teachers.AddAsync(teacher);
            await OzelDersYerimContext.SaveChangesAsync();
            teacher.TeacherBranches = selectedBranchIds
            .Select(branchId=> new TeacherBranch {
                TeacherId=teacher.Id,
                BranchId=branchId
            }).ToList();
            await OzelDersYerimContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
           var teacher = await OzelDersYerimContext
           .Teachers
           .Include(t=>t.User)
            .Include(t=>t.TeacherBranches)
            .ThenInclude(tb=>tb.Branch)
           .ToListAsync();

           return teacher;

        }

        public async Task<List<Teacher>> GetBranchByTeacherAsync(string branchUrl)
        {
            var teachers = OzelDersYerimContext
                .Teachers
                //.Where(t => t.User.EmailConfirmed == true)
                .AsQueryable();
            if (branchUrl != null)
            {
                teachers =
                    teachers.Include(t => t.TeacherBranches)
                    .ThenInclude(tb => tb.Branch)
                   
                    .Where(t => t.TeacherBranches.Any(tb => tb.Branch.Url == branchUrl));
            }
            return await teachers.ToListAsync();
        }
        

        public async Task<List<Teacher>> GetHomePageTeachersAsync()
        {
            return await OzelDersYerimContext.
                Teachers.
                Where(t => t.IsHome == true)
                .ToListAsync();

        }

        public async Task<User> GetTeacherByUser(string userName)
        {
            var user = await  OzelDersYerimContext.
                Users
                .Include(t => t.Teachers)
                .ThenInclude(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                
                .FirstOrDefaultAsync(ut => ut.UserName == userName );
            return user;

        }

        public async Task<Teacher> GetTeacherDetailsByUrl(string teacherUrl)
        {
            var teacher = await OzelDersYerimContext
                .Teachers
                .Where(t => t.Url == teacherUrl)
                .Include(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .Include(t => t.TeacherLessons)
                .ThenInclude(tl => tl.Lesson)
                .Include(t=>t.User)
                .FirstOrDefaultAsync();
            return teacher;
        }

        public async Task<Teacher> GetTeachersWithBranchesAsync(int id)
        {
          var teacher= await OzelDersYerimContext
                .Teachers
                .Where(t => t.Id == id)
                .Include(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .Include(t => t.User)
                .FirstOrDefaultAsync();
            return teacher;
        }

        public async Task UpdateTeacherAsync(Teacher teacher, int[] selectedBranchIds)
        {
            Teacher newTeacher =  await OzelDersYerimContext
                .Teachers
                .Include(t => t.TeacherBranches)
                .FirstOrDefaultAsync(t=>t.Id==teacher.Id);

            newTeacher.TeacherBranches =selectedBranchIds
                .Select(branchId => new TeacherBranch
                {
                    TeacherId = newTeacher.Id,
                    BranchId = branchId
                }).ToList();
            OzelDersYerimContext.Update(newTeacher);
            await OzelDersYerimContext.SaveChangesAsync();
        }

     
    }
}
