using AppCrudEFCoreApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudEFCoreApi.Api.Data
{
    public class UserRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users
                .AsNoTracking()
                .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.UserId == id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
