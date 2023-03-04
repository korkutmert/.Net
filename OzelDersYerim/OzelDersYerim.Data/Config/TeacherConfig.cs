using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDersYerim.Data.Extensions;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Gender).HasMaxLength(20);
            builder.Property(t => t.DateOfBirth).IsRequired();
            builder.Property(t => t.About).HasMaxLength(500);
            builder.Property(t => t.Experience).HasMaxLength(50);

            builder.Property(t => t.Url).HasMaxLength(250);
            builder.Property(t => t.ProfilePictureUrl).HasMaxLength(250);
            builder.Property(t => t.Location).HasMaxLength(11);

            builder.ToTable("Teachers");
            builder.HasData
                (
                    new Teacher
                    {
                        Id = 1,
                        UserId = "36c1db42-7495-477f-921e-ba037f5188ed",
                        FirstName = "Ahmet",
                        LastName = "Yılmaz",
                        Gender = "Erkek",
                    DateOfBirth=new DateTime(1978,5,19),
                        About = "Samsun 19 Mayıs Universitesi Matematik Bölümü mezunuyum.",
                        Experience = "15",
                        Location = "Beşiktaş",
                        Url = "ogretmen-ahmet-yilmaz",
                        ProfilePictureUrl = "10.png",
                        PricePerHour = 450,
                        IsHome = true,



                    },
                     new Teacher
                     {
                         Id = 2,
                         FirstName = "Arzu",
                         LastName = "Doğramacı",
                         Gender = "Kadın",
                    DateOfBirth=new DateTime(1985,5,19),
                         About = "İngilizce Öğretmeniyim. Her türlü İngilizce sınavlarına hazırlık konusunda ders vermekteyim.",
                         Experience = "5",
                         Location = "Şişli",
                         Url = "ogretmen-arzu-dogramaci",
                         ProfilePictureUrl = "11.png",
                         PricePerHour = 300,
                         UserId = "arzu"


                     }, new Teacher
                     {
                         Id = 3,
                         FirstName = "Mehmet",
                         LastName = "Yıldırım",
                         Gender = "Erkek",
                    DateOfBirth=new DateTime(1990,5,19),
                         About = "Boğaziçi Üniversitesi Mezunuyum. 28 yaşındayım. Özel bir lisede Kimya Öğretmenliği yapıyorum.",
                         Experience = "6",
                         UserId = "ahj8-ahjs-87yht",
                         Location = "Etiler",
                         Url = "ogretmen-mehmet-yildirim",
                         ProfilePictureUrl = "12.png",
                         PricePerHour = 300,
                         


                     }
                //, new Teacher
                //{
                //    Id = 5,

                //    FirstName = "Burak",
                //    LastName = "Yılmaz",
                //    Gender = "Erkek",
                //    Age = "30",
                //    About = "Samsun 19 Mayıs Universitesi Matematik Bölümü mezunuyum. Aynı zamanda Elektro Gitar dersleri vermekteyim.",
                //    Experience = "7",

                //    Location = "Mecidiyeköy",
                //    Url = "ogretmen-burak-yilmaz",
                //    ProfilePictureUrl = "14.png",
                //    PricePerHour = 400,
                //    BranchId = 4



                //}, new Teacher
                //{
                //    Id = 6,

                //    FirstName = "Hasan Can",
                //    LastName = "Güzel",
                //    Gender = "Erkek",
                //    Age = "29",
                //    About = "Türk Dili Ve Edebiyatı, Türkçe, Dil Anlatım gibi dersler uzmanlık alanım olup, her türlü sınav için ders veriyorum.",

                //    Experience = "7",
                //    Location = "Beşiktaş",
                //    Url = "ogretmen-hasan-can-guzel",
                //    ProfilePictureUrl = "15.png",
                //    PricePerHour = 200,
                //    BranchId = 5


                //},
                //new Teacher
                //{
                //    Id = 7,
                //    FirstName = "Hakkı ",
                //    LastName = "Sarıca",
                //    Gender = "Erkek",
                //    Age = "42",
                //    About = "Back-End ve Front-End development konularında A'dan Z'ye eğitim vermekteyim. Sektörde Senior Developer olarak çalıştım.",

                //    Experience = "21",
                //    Location = "Esenler",
                //    Url = "ogretmen-hakki-sarica",
                //    ProfilePictureUrl = "16.png",
                //    PricePerHour = 700,
                //    BranchId = 6


                //}
                );




        }
    }
}
