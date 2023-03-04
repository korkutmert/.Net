using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task CreateAsync(Student student)
        {
            await _unitOfWork.Students.CreateAsync(student);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Student student)
        {
            _unitOfWork.Students.Delete(student);
            _unitOfWork.Save();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();

        }
        public void Update(Student student)
        {
            _unitOfWork.Students.Update(student);
             _unitOfWork.Save();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

        public Task<User> GetStudentByUser(string username)
        {
            return _unitOfWork.Students.GetStudentByUser(username);

        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _unitOfWork.Students.GetAllStudents();
        }

        public async Task CreateStudent(Student student)
        {
            await _unitOfWork.Students.CreateStudent(student);
        }

        public async Task<Student> GetStudentDetailsByUrl(string studentUrl)
        {
           return await _unitOfWork.Students.GetStudentDetailsByUrl(studentUrl);
        }
    }
}
