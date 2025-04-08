using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class PaymentRepository : IRepository<Payments>
    {
        private readonly ApplicationdbContext _context;

        public PaymentRepository(ApplicationdbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Payments entity)
        {
            await _context.Payments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Payment = await _context.Payments.FindAsync(id);
            if(Payment != null) 
            {
                 _context.Payments.Remove(Payment);
                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new KeyNotFoundException();
            }
        }

        public Task<IEnumerable<Payments>> FindAllAsync(Func<Payments, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Payments> FindAsync(Expression<Func<Payments, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Payments>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public Task<Payments> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Payments> GetByIdAsync(int id)
        {
            var Payment = await _context.Payments.FindAsync(id);
            if(Payment != null) 
            {
                return Payment;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public Task<Payments> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Payments entity)
        {
            _context.Payments.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
