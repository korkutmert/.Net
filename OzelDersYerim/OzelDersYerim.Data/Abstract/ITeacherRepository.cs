using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<List<Teacher>> GetBranchByTeacherAsync(string branchUrl);
        Task<List<Teacher>> GetHomePageTeachersAsync();
        public Task<User> GetTeacherByUser(string userName);
         public Task<List<Teacher>> GetAllTeacher();
         Task CreateTeacher(Teacher teacher, int[] selectedBranchIds);

        Task UpdateTeacherAsync(Teacher teacher, int[] selectedBranchIds);

        Task<Teacher> GetTeachersWithBranchesAsync(int id);
        Task<Teacher> GetTeacherDetailsByUrl(string teacherUrl);
        


    }
}
