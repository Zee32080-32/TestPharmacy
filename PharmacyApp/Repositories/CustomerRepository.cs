using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class CustomerRepository : IRepository<Customers>
    {
        private readonly ApplicationdbContext _context;
        public CustomerRepository(ApplicationdbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Customers entity)
        {

            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Customer = await _context.Customers.FindAsync(id);
            if (Customer == null) 
            {
                throw new Exception();
            }
            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customers> GetByIdAsync(int id )
        {
            
           var user = await _context.Customers.FindAsync(id);
            if(user == null) 
            { 
                throw new Exception();
            }
            return user;


        }

        public async Task<Customers> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task UpdateAsync(Customers entity)
        {
             _context.Customers.Update(entity);
            await _context.SaveChangesAsync();

        }

        public Task<Customers> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Customers> FindAsync(Expression<Func<Customers, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customers>> FindAllAsync(Func<Customers, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
