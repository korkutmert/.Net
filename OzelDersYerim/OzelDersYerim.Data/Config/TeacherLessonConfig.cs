using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Data.Config
{
    public class TeacherLessonConfig : IEntityTypeConfiguration<TeacherLesson>
    {
        public void Configure(EntityTypeBuilder<TeacherLesson> builder)
        {
            builder.HasKey(tl=> new {tl.TeacherId, tl.LessonId});
           builder.ToTable("TeachersLessons");
            builder.HasData
            (
                new TeacherLesson{
                    LessonId=2,
                    TeacherId=3
                },
                 new TeacherLesson{
                    LessonId=1,
                    TeacherId=1
                },
                 new TeacherLesson{
                    LessonId=3,
                    TeacherId=2
                }
            );
        }
    }
}