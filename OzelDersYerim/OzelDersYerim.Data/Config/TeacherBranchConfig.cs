using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete;

namespace OzelDersYerim.Data.Config
{
  
        public class TeacherBranchConfig : IEntityTypeConfiguration<TeacherBranch>
        {
            public void Configure(EntityTypeBuilder<TeacherBranch> builder)
            {
                builder.HasKey(tb=> new { tb.TeacherId,tb.BranchId  });
             
                builder.ToTable("TeacherBranches");

                builder.HasData(
                    new TeacherBranch { TeacherId = 1, BranchId = 1 },
                    new TeacherBranch { TeacherId = 1, BranchId = 2 },
                    new TeacherBranch { TeacherId = 2, BranchId = 1 },
                    new TeacherBranch { TeacherId = 2, BranchId = 2 },
                    new TeacherBranch { TeacherId = 3, BranchId = 4 },
                    new TeacherBranch { TeacherId = 3, BranchId = 5 }
                    );
            }
        }
}
