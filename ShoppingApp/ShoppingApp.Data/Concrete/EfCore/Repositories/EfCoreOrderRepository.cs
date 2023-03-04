using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(ShopAppContext context) : base(context)
        {
        }
        private ShopAppContext ShopAppContext
        {
            get { return _context as ShopAppContext; }
        }
        public async Task<List<Order>> GetOrders(string userId = null)
        {
            #region UserIdNull Kontrolü yapılmadan
            //var orders = ShopAppContext.Orders
            //   .Where(o => o.UserId == userId)
            //   .Include(o => o.OrderItems)
            //   .ThenInclude(oi => oi.Product)
            //   .ToList();
            //return orders;
            #endregion

            #region UserIdNull Kontrolü Yapılarak
            var orders = ShopAppContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .AsQueryable();
            if (!String.IsNullOrEmpty(userId)) // userId eğer null değilse
            {
               orders= orders.Where(o=>o.UserId == userId);
            }
            return orders.ToList();
            #endregion
        }
    }
}
