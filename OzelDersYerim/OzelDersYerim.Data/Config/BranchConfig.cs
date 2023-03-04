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
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.BranchName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Url).IsRequired().HasMaxLength(250);
            builder.Property(b => b.ImageUrl).HasMaxLength(250);

            builder.ToTable("Branches");

            builder.HasData
                (
                    new Branch
                    {
                        Id= 1,
                         BranchName="Matematik",
                          Url="matematik",
                          Description="Matematik dersleri burada yer alır.",
                          ImageUrl= "matematik.png",
                           CreatedDate=DateTime.Now
                    },
                     new Branch
                     {
                         Id = 2,
                         BranchName = "Kimya",
                         Url = "kimya",
                          Description="Kimya dersleri burada yer alır.",
                         ImageUrl = "kimya.png",
                           CreatedDate=DateTime.Now

                     }, new Branch
                     {
                         Id = 3,
                         BranchName = "İngilizce",
                         Url = "ingilizce",
                          Description="İngilizce dersleri burada yer alır.",
                         ImageUrl = "ingilizce.png",
                           CreatedDate=DateTime.Now

                     }, new Branch
                     {
                         Id = 4,
                         BranchName = "Müzik",
                         Url = "muzik",
                          Description="Müzik dersleri burada yer alır.",
                         ImageUrl = "muzik.png",
                           CreatedDate=DateTime.Now

                     }, new Branch
                     {
                         Id = 5,
                         BranchName = "Türkçe",
                         Url = "turkce",
                          Description="Türkçe dersleri burada yer alır.",
                         ImageUrl = "turkce.png",
                           CreatedDate=DateTime.Now

                     }, new Branch
                     {
                         Id = 6,
                         BranchName = "Bilgisayar",
                         Url = "bilgisayar",
                          Description="Bilgisayar dersleri burada yer alır.",
                         ImageUrl = "bilgisayar.png",
                           CreatedDate=DateTime.Now

                     }
                );
        }
    }
}
