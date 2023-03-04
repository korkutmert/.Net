using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;

namespace OzelDersYerim.Business.Concrete
{

    public class LessonManager : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Genel
        public async Task CreateAsync(Lesson lesson)
        {
            await _unitOfWork.Lessons.CreateAsync(lesson);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Lesson lesson)
        {
            _unitOfWork.Lessons.Delete(lesson);
            _unitOfWork.SaveAsync();
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _unitOfWork.Lessons.GetAllAsync();
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            return await _unitOfWork.Lessons.GetByIdAsync(id);
        }

        public void Update(Lesson lesson)
        {
            _unitOfWork.Lessons.Update(lesson);
            _unitOfWork.Save();
        }
        #endregion


        #region Lesson
        public async Task<Teacher> GetTeacherWithLesson(int id)
        {
            return await _unitOfWork.Lessons.GetTeacherWithLesson(id);
        }

        public async Task<Student> GetStudentWithLesson(int id)
        {
            return await _unitOfWork.Lessons.GetStudentWithLesson(id);
        }

        public async Task<List<StudentLesson>> GetAllStudentLessons()
        {
            return await _unitOfWork.Lessons.GetAllStudentLessons();
        }

        public async Task<List<TeacherLesson>> GetAllTeacherLessons()
        {
            return await _unitOfWork.Lessons.GetAllTeacherLessons();
        }

        public async Task<List<Lesson>> GetAllLessonsWithTeacherAndStudent()
        {
            return await _unitOfWork.Lessons.GetAllLessonsWithTeacherAndStudent();
        }

        public async Task<List<TeacherLesson>> GetTeacherLessonsByUserName(string userName)
        {
            return await _unitOfWork.Lessons.GetTeacherLessonsByUserName(userName);
        }

        public async Task<TeacherLesson> GetTeacherLessonByLessonId(int id)
        {
            return await _unitOfWork.Lessons.GetTeacherLessonByLessonId(id);
        }

        public async Task<Teacher> GetTeacherByLessonId(int id)
        {
            return await _unitOfWork.Lessons.GetTeacherByLessonId(id);
        }

        public async Task<StudentLesson> GetStudentLessonByLessonId(int id)
        {
            return await _unitOfWork.Lessons.GetStudentLessonByLessonId(id);
        }

        public async Task<List<StudentLesson>> GetStudentLessonsByUserName(string userName)
        {
            return await _unitOfWork.Lessons.GetStudentLessonsByUserName(userName);
        }
        #endregion

    }
}