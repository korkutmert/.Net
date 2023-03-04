using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IBranchRepository Branches { get; }
        ILessonRepository Lessons { get; }
        Task SaveAsync();
        void Save();
    }
}
