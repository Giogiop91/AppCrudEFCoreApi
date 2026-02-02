using AppCrudEFCoreApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudEFCoreApi.Api.Data
{
    public class ProductRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products
                .AsNoTracking()
                .ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.ProductId == id);
        }


        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}

