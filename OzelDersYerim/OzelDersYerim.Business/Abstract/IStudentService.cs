using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Business.Abstract
{
    public interface IStudentService
    {

        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        Task CreateAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
        public Task<User> GetStudentByUser(string username);
        Task<List<Student>> GetAllStudents();
        Task CreateStudent(Student student);

        public Task<Student> GetStudentDetailsByUrl(string studentUrl);
        
    }
}
