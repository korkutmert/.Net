using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IKitapRepository : IGenericRepository<Kitap>
    {
        //Þu an burada IGenericRepository'den gelen Kitap için hazýrlnamýþ CRUD metotlar var.
        //Eðer bir class IKitapRepository'den miras alýrsa, tüm bu CRUD metotlarý da oraya implemente edilir.
        //Buraya ayrýca yazýlacak metotlar(aþaðýdaki gibi) sadece Kitap entitysine özgü metotlardýr.
        List<Kitap> KategoriyeGoreKitapListesi(int id);
    }
}