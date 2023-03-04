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
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(DbContext context) : base(context)
        {
        }
        private OzelDersYerimContext OzelDersYerimContext
        {
            get { return _context as OzelDersYerimContext; }
        }

        public async Task CreateStudent(Student student)
        {
            await OzelDersYerimContext.Students.AddAsync(student);
            await OzelDersYerimContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await OzelDersYerimContext
                .Students
                .Include(s => s.User)
                .ToListAsync();
            return students;
        }

        public Task<User> GetStudentByUser(string username)
        {
            var user = OzelDersYerimContext
                .Users
               .Include(t =>t.Students)
               .FirstOrDefaultAsync(ut => ut.UserName == username);
            return user;
        }

        public Task<Student> GetStudentDetailsByUrl(string studentUrl)
        {
            var student= OzelDersYerimContext
                .Students
                .Where(s => s.Url == studentUrl)
                .Include(p => p.User)
                .Include(s=>s.StudentLessons)
                .ThenInclude(sl=>sl.Lesson)               
                .FirstOrDefaultAsync();
            return student;
        }
    }
}
