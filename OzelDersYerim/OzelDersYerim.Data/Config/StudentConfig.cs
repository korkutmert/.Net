using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDersYerim.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
            builder.Property(s=>s.DateOfBirth).IsRequired();
            builder.Property(s => s.Url).HasMaxLength(250);
            builder.Property(s => s.ProfilePictureUrl).HasMaxLength(250);
            

            builder.ToTable("Students");
            builder.HasData
                (
                new Student
                {
                    Id = 1,
                    FirstName = "Mert Korkut",
                    LastName = "Muslu",
                    UserId = "f51a33d9-90b7-4304-8f27-296121b22ed8",
                    DateOfBirth=new DateTime(1999,10,28),
                    Gender = "Erkek",
                    Url = "ogrenci-mert-korkut-muslu",
                    ProfilePictureUrl = "1.png",
                    Location = "Kadıköy"


                },
                new Student
                {
                   Id = 2,
                   FirstName = "Cemre ",
                   LastName = "Şenel",
                   UserId="c3Mr3-s77Nel",
                   DateOfBirth=new DateTime(1995,7,21),
                   Gender="Erkek",
                   Url = "ogrenci-cemre-senel",
                   ProfilePictureUrl = "2.png",
                   Location="Beşiktaş"
                 
                }
                // new Student
                //{
                //    Id = 3,
                //    FirstName = "Harun ",
                //    LastName = "Özer",
                //    Age="23",
                //    Gender="Erkek",
                //    Url = "ogrenci-harun-ozer",
                //    ProfilePictureUrl = "3.png",
                //    Location="Kadıköy",
                //    About = "Kendimi her alanda gelişime açık hissediyorum. Back-end developer alanında çalışmak istediğim içinde özellikle bu alanda kendime birşeyler katmak istiyorum."

                //}, new Student
                //{
                //    Id = 4,
                //    FirstName = "Senem",
                //    LastName = "Öztürk",
                //    Age="20",
                //    Gender="Kadın",
                //    Url = "ogrenci-senem-ozturk",
                //    ProfilePictureUrl = "4.png",
                //    Location="Kadıköy",
                //    About = "Yeni mezun bir sağlıkçı olarak Kpss sınavlarına hazırlanmak için matematik dersleri almak istiyorum."
                //},
                //new Student
                //{
                //    Id = 5,

                //    FirstName = "Zeynep",
                //    LastName = "Aslan",
                //    Age = "14",
                //    Url = "ogrenci-zeynep-aslan",
                //    Gender="Kadın",
                //    ProfilePictureUrl = "5.png",
                //    Location="Kadıköy",
                //    About = "Matematik derslerinde çok zorlanıyorum."
                //},
                //new Student
                //{
                //    Id = 6,

                //    FirstName = "Kemal Emre",
                //    LastName = "Erol",
                //    Age = "22",
                //    Gender="Erkek",
                //    Url = "ogrenci-kemal-emre-erol",
                //    ProfilePictureUrl = "6.png",
                //    Location="Kadıköy",
                //    About = "Merhaba.Herhangi bir müzik aleti çalmayı öğrenmek için buradayım !."
                //},
                //new Student
                //{
                //    Id = 7,

                //    FirstName = "Aslı",
                //    LastName = "Yıldız",
                //    Age = "17",
                //    Gender="Kadın",
                //    Url = "ogrenci-asli-yildiz",
                //    ProfilePictureUrl = "7.png",
                //    Location="Kadıköy",
                //    About = "Lise öğrencisiyim.Üniversite sınavları için Kimya dersleri almak istiyorum."

                //}
                ) ;



        }
    }
}
