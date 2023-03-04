using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Data.Concrete.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Concrete.EfCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OzelDersYerimContext _context;

        public UnitOfWork(OzelDersYerimContext context)
        {
            _context = context;
        }
        private EfCoreBranchRepository _branchRepository;
        private EfCoreStudentRepository _studentRepository;
        private EfCoreTeacherRepository _teacherRepository;
        private EfCoreLessonRepository _lessonRepository;

        public IStudentRepository Students => _studentRepository = _studentRepository ?? new EfCoreStudentRepository(_context);

        public ITeacherRepository Teachers => _teacherRepository=_teacherRepository ?? new EfCoreTeacherRepository(_context);

        public IBranchRepository Branches => _branchRepository=_branchRepository?? new EfCoreBranchRepository(_context);

        public ILessonRepository Lessons => _lessonRepository=_lessonRepository?? new EfCoreLessonRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public  void Save()
        {
             _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
