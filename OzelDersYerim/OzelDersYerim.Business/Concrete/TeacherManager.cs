using Microsoft.AspNetCore.Identity;
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
    public class TeacherManager : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
   

       
        #region GENERİC
        public async Task CreateAsync(Teacher teacher)
        {
            await _unitOfWork.Teachers.CreateAsync(teacher);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Teacher teacher)
        {
            _unitOfWork.Teachers.Delete(teacher);
            _unitOfWork.Save();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();

        }
        public void Update(Teacher teacher)
        {
            _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Save();

        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(id);
        }
        #endregion

        #region TEACHER
        public async Task<List<Teacher>> GetHomePageTeachers()
        {
            return await _unitOfWork.Teachers.GetHomePageTeachersAsync();
        }
        public async Task<List<Teacher>> GetBranchByTeacher(string branchUrl)
        {
            return await _unitOfWork.Teachers.GetBranchByTeacherAsync(branchUrl);

        }

        public Task<User> GetTeacherByUser(string userName)
        {
            return _unitOfWork.Teachers.GetTeacherByUser(userName);
            
        }

         public async Task<List<Teacher>> GetAllTeacher()
        {
           return await _unitOfWork.Teachers.GetAllTeacher();
        }

        public async Task CreateTeacher(Teacher teacher, int[] selectedBranchIds)
        {
            await _unitOfWork.Teachers.CreateTeacher(teacher, selectedBranchIds);
        }

        public async Task UpdateTeacherAsync(Teacher teacher, int[] selectedBranchIds)
        {
            await _unitOfWork.Teachers.UpdateTeacherAsync( teacher, selectedBranchIds);
        }

        public async Task<Teacher> GetTeachersWithBranchesAsync(int id)
        {
            return await _unitOfWork.Teachers.GetTeachersWithBranchesAsync(id);
        }

        public async Task<Teacher> GetTeacherDetailsByUrl(string teacherUrl)
        {
            return await _unitOfWork.Teachers.GetTeacherDetailsByUrl(teacherUrl);
        }





        #endregion


    }
}
