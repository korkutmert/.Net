using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Data.EfCore.Abstract;
using KitabeviApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace KitabeviApp.Data.EfCore.Concrete
{
    public class EfCoreKitapRepository : EfCoreGenericRepository<Kitap>, IKitapRepository
    {
        public List<Kitap> KategoriyeGoreKitapListesi(int id)
        {
            throw new NotImplementedException();
        }
    }
}
