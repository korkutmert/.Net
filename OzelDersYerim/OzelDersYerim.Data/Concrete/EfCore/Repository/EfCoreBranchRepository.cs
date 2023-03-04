using Microsoft.EntityFrameworkCore;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Data.Concrete.EfCore.Repository
{
    public class EfCoreBranchRepository : EfCoreGenericRepository<Branch>, IBranchRepository
    {
        public EfCoreBranchRepository(DbContext context) : base(context)
        {
        }
    }
}
