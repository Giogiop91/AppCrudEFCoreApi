using AppCrudEFCoreApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudEFCoreApi.Api.Data
{
    public class OrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Insert(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetAllWithRelations()
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Product)
                .AsNoTracking()
                .ToList();
        }

        public Order? GetByIdWithRelations(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Product)
                .AsNoTracking()
                .FirstOrDefault(o => o.OrderId == id);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
