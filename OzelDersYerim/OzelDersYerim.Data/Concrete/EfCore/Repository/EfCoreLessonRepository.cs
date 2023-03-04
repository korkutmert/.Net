using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Data.Concrete.EfCore.Context;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;

namespace OzelDersYerim.Data.Concrete.EfCore.Repository
{
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        public EfCoreLessonRepository(DbContext context) : base(context)
        {
        }
        private OzelDersYerimContext OzelDersYerimContext
        {
            get { return _context as OzelDersYerimContext; }
        }

        public async Task<List<Lesson>> GetAllLessonsWithTeacherAndStudent()
        {
            var LESSON = await OzelDersYerimContext.Lessons.ToListAsync(); return LESSON; 
        }

        public async Task<List<StudentLesson>> GetAllStudentLessons()
        {
            var studentLesson = await OzelDersYerimContext
            .StudentLessons
            .Include(sl => sl.Lesson)
            .ThenInclude(l=>l.Branch)
            .Include(sl => sl.Student)
            .ThenInclude(s=>s.User)
            .ToListAsync();
            return studentLesson;
        }

        public async Task<List<TeacherLesson>> GetAllTeacherLessons()
        {
            var teacherLesson = await OzelDersYerimContext
           .TeacherLessons
           .Include(tl => tl.Lesson)
           .ThenInclude(l=>l.Branch)
           .Include(sl => sl.Teacher)
           .ThenInclude(t=>t.User)
           .ToListAsync();
            return teacherLesson;
        }

        public async Task<StudentLesson> GetStudentLessonByLessonId(int id)
        {
            var studentLesson= await OzelDersYerimContext
            .StudentLessons
            .Include(sl=>sl.Lesson)
            .ThenInclude(l=>l.Branch)
                .Where(sl => sl.LessonId == id)
                .FirstOrDefaultAsync();
            return studentLesson;

        }

        public async Task<Student> GetStudentWithLesson(int id)
        {
            var student = await OzelDersYerimContext
            .Students
            .Where(s => s.Id == id)
            .Include(s => s.StudentLessons)
            .ThenInclude(sl => sl.Lesson)
            .Include(s => s.User)
            .FirstOrDefaultAsync();
            return student;
        }

        public async Task<Teacher> GetTeacherByLessonId(int id)
        {
            var teachers = OzelDersYerimContext
                 .Teachers.Include(t => t.User)
                 //.Where(t => t.User.EmailConfirmed == true)
                 .AsQueryable();
            if (id != 0)
            {
                teachers =
                    teachers.Include(t => t.TeacherLessons)
                    
                    .ThenInclude(tl => tl.Lesson)

                    .Where(t => t.TeacherLessons.Any(tb => tb.Lesson.Id == id));
            }
            return await teachers.FirstOrDefaultAsync();
        }

        public async Task<TeacherLesson> GetTeacherLessonByLessonId(int id)
        {
            var teacherLesson = await OzelDersYerimContext
                .TeacherLessons
                .Include(tl => tl.Lesson)
                .ThenInclude(l=>l.Branch)
                .Where(tl => tl.LessonId == id)
                .FirstOrDefaultAsync();
            return teacherLesson;
        }
            public async Task<List<StudentLesson>> GetStudentLessonsByUserName(string userName)
        {
            var studentLessons = await OzelDersYerimContext
                .StudentLessons
                .Include(sl => sl.Student)
                .ThenInclude(s=> s.User)
                .Where(sl => sl.Student.User.UserName == userName)
                .Include(sl => sl.Lesson).ThenInclude(l => l.Branch)
                .ToListAsync();
            return studentLessons;
        }

        public async Task<List<TeacherLesson>> GetTeacherLessonsByUserName(string userName)
        {
            var teacherLessons = await OzelDersYerimContext
                .TeacherLessons
                .Include(tl => tl.Teacher)
                .ThenInclude(t => t.User)
                .Where(tl => tl.Teacher.User.UserName == userName)
                .Include(tl => tl.Lesson).ThenInclude(l => l.Branch)
                .ToListAsync();
            return teacherLessons;
        }

        public async Task<Teacher> GetTeacherWithLesson(int id)
        {
            var teacher = await OzelDersYerimContext
                .Teachers
                .Where(t => t.Id == id)
                .Include(t => t.TeacherLessons)
                .ThenInclude(tl => tl.Lesson)
                //.ThenInclude(l => l.Branch)
                .Include(t => t.User)
                .FirstOrDefaultAsync();
            return teacher;
        }
    }
}