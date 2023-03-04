using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;

namespace OzelDersYerim.Business.Abstract
{
    public interface ILessonService
    {
         Task<Lesson> GetByIdAsync(int id);
        Task<List<Lesson>> GetAllAsync();
        Task CreateAsync(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(Lesson lesson);
        Task<Teacher> GetTeacherWithLesson(int id);
        Task<Student> GetStudentWithLesson(int id);
        Task<List<StudentLesson>>GetAllStudentLessons();
        Task<List<TeacherLesson>>GetAllTeacherLessons();
        Task<List<Lesson>> GetAllLessonsWithTeacherAndStudent();
        Task<List<TeacherLesson>> GetTeacherLessonsByUserName(string userName);
        Task<TeacherLesson> GetTeacherLessonByLessonId(int id);
        Task<StudentLesson> GetStudentLessonByLessonId(int id);
        Task<Teacher> GetTeacherByLessonId(int id);
       Task<List<StudentLesson>> GetStudentLessonsByUserName(string userName);
    }
}