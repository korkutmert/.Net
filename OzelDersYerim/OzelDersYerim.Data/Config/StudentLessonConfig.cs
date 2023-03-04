using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Data.Config
{
    public class StudentLessonConfig : IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
           builder.HasKey(sl => new { sl.StudentId, sl.LessonId });
           builder.ToTable("StudentsLessons");
            builder.HasData
            (
                new StudentLesson{
                    StudentId=1,
                    LessonId=1
                },
                 
                  new StudentLesson{
                    StudentId=2,
                    LessonId=3
                }
            );
        }
    }
}