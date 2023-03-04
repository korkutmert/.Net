using Microsoft.AspNetCore.Identity;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Business.Abstract
{
    public interface ITeacherService
    {

        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        Task CreateAsync(Teacher teacher);
        void Update(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher, int[] selectedBranchIds);

        void Delete(Teacher teacher);
        Task<List<Teacher>> GetBranchByTeacher(string branchUrl);
        Task<List<Teacher>> GetHomePageTeachers();
        public Task<User> GetTeacherByUser(string userName);

        Task<List<Teacher>> GetAllTeacher();
        Task CreateTeacher(Teacher teacher, int[] selectedBranchIds);
        Task <Teacher> GetTeachersWithBranchesAsync(int id);
        Task<Teacher> GetTeacherDetailsByUrl(string teacherUrl);
        



     
        

    }
}
