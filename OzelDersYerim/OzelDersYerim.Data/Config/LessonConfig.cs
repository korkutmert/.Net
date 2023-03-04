using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Data.Config
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l=>l.Id);
            
            
           builder.ToTable("Lessons");

       
       builder.HasData(
        new Lesson{
            Id=1,
            Name="TYT-Matematik hazırlık dersleri.",
            Url="tyt-matematik-hazirlik-dersleri",
            Description="Sınav öncesi tekar, özel konu analıtımı ve soru çözümü kampı içeriklidir.",
            PricePerHour=150,
            BranchId=1,
            
        },
        new Lesson{
            Id=2,
            Name="Lise düzeyinde Kimya dersleri.",
            Url="lise-duzeyinde-kimya-dersleri",
            Description="Üniversite sınavlarına ve okul sınavlarına özel etüd yapılır.",
            PricePerHour=100,
            BranchId=2, 
        },
          
         new Lesson{
            Id=3,
            Name="A1-C2 arası konuşma pratikli İnglizce eğitimi.",
            Url="a1-c2-arasi-konusma-pratikli-inglizce-egitimi.",
            Description="Dil Bilgisi,yazma ve konuşma olarak ileri seviye bir eğitim.",
            PricePerHour=250,
            BranchId=3, 
        }
        //    new Lesson{
        //     Id=4,
        //     Name="Enstrüman ve ses eğitimi.",
        //     Url="enstruman-ve-ses-egitimi",
        //     Description="Gitar, keman eğitimleri ile birlikte ses eğitimi verilmektedir.",
        //     PricePerHour=500,
        //     BranchId=4, 
        // },
        //  new Lesson{
        //     Id=5,
        //     Name="Sınavlara hazırlık Türkçe dersleri.",
        //     Url="sinavlara-hazrilik-turkce-dersleri",
        //     Description="Türkçe derslerinde sınava hazırlık kursu.",
        //     PricePerHour=100,
        //     BranchId=5, 
        // },
        //  new Lesson{
        //     Id=6,
        //     Name="C# programlama eğitimi.",
        //     Url="c#-programlama-egitimi",
        //     Description="İşletim sistemi kurulumu ve kullanımı ile ilgili eğitimler.",
        //     PricePerHour=200,
        //     BranchId=6, 
        // }
      
       );
         
            
        }
    }
}