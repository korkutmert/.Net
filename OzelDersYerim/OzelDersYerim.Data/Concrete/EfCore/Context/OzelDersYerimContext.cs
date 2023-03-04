using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OzelDersYerim.Data.Config;
using OzelDersYerim.Data.Extensions;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Concrete.EfCore.Context
{
    public class OzelDersYerimContext : IdentityDbContext<User,IdentityRole,string>
    {
        public OzelDersYerimContext(DbContextOptions<OzelDersYerimContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<TeacherBranch> TeacherBranches { get; set; }
        public DbSet<Lesson> Lessons{get; set;}
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = OzelDersYerim.db");
  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.SeedData();
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new BranchConfig());
            modelBuilder.ApplyConfiguration(new LessonConfig());
            modelBuilder.ApplyConfiguration(new TeacherBranchConfig());
            modelBuilder.ApplyConfiguration(new TeacherLessonConfig());
            modelBuilder.ApplyConfiguration(new StudentLessonConfig());
            modelBuilder.Entity<User>()
                .Property("ThisUserRole")
                .HasColumnType("text");
            base.OnModelCreating(modelBuilder);
           

        }

    }

}
