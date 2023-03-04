using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        public Task<User> GetStudentByUser(string username);
        public Task<List<Student>> GetAllStudents();

        Task CreateStudent(Student student);

        public Task<Student> GetStudentDetailsByUrl(string studentUrl);

        

    }
}
