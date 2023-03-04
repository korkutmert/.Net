using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelDersYerim.Data.Config;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="ADMIN",
                },

                  new IdentityRole
                {
                    Name="Student",
                    NormalizedName="STUDENT"
                },
                  new IdentityRole
                {
                    Name="Teacher",
                    NormalizedName="TEACHER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            List<User> users = new List<User>
            {
               
                new User
                      {
                          Id="f51a33d9-90b7-4304-8f27-296121b22ed8",
                          Email="student@gmail.com",
                          ThisUserRole="Student",
                          UserName="xwe",
                          NormalizedEmail="STUDENT@GMAIL.COM",
                          NormalizedUserName="XWE",
                          PhoneNumber="05557778855"
                          
                          
                      },
                 new User
                     {
                         Id="36c1db42-7495-477f-921e-ba037f5188ed",
                         Email="teacher@gmail.com",
                          ThisUserRole="Teacher",
                          UserName="abc",
                          NormalizedEmail="TEACHER@GMAIL.COM",
                          NormalizedUserName="ABC",
                          PhoneNumber="05556669944"


                     },
                 
                 new User
                     {
                         Id="arzu",
                          ThisUserRole="Teacher",
                         Email="arzu@gmail.com",
                          UserName="klm",
                          NormalizedEmail="ARZU@GMAIL.COM",
                          NormalizedUserName="KLM",
                          PhoneNumber="05557778855"

                     },
                 new User
                     {
                         Id="admin",
                          ThisUserRole="Admin",
                         Email="admin@gmail.com",
                          UserName="admin",
                          NormalizedEmail="ADMIN@GMAIL.COM",
                          NormalizedUserName="ADMIN",
                          PhoneNumber="05551112233"


                     },new User
                     {
                         Id="ahj8-ahjs-87yht",
                         Email="mehmet@gmail.com",
                          ThisUserRole="Teacher",
                          UserName="mehmetthoca",
                          NormalizedEmail="MEHMET@GMAIL.COM",
                          NormalizedUserName="MEHMETHOCA",
                          PhoneNumber="05553335566"

                     },
                       new User
                      {
                          Id="c3Mr3-s77Nel",
                          Email="cemre@gmail.com",
                          ThisUserRole="Student",
                          UserName="CemreSenel",
                          NormalizedEmail="CEMRE@GMAIL.COM",
                          NormalizedUserName="CEMRESENEL",
                          PhoneNumber="05557770606"
                          
                          
                      }

            };
            modelBuilder.Entity<User>().HasData(users);

            var password = new PasswordHasher<User>();
            users[0].PasswordHash = password.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = password.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = password.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = password.HashPassword(users[3], "Admin123.");
            users[4].PasswordHash = password.HashPassword(users[4], "Qwe123.");
            users[5].PasswordHash = password.HashPassword(users[5], "Qwe123.");

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {

                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles.First(r=>r.Name=="Student").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles.First(r=>r.Name=="Teacher").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[2].Id,
                    RoleId=roles.First(r=>r.Name=="Teacher").Id
                                    
                },
                new IdentityUserRole<string>
                {
                    UserId=users[3].Id,
                    RoleId=roles.First(r=>r.Name=="Admin").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[4].Id,
                    RoleId=roles.First(r=>r.Name=="Teacher").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[5].Id,
                    RoleId=roles.First(r=>r.Name=="Student").Id
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
