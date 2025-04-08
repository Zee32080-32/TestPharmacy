using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetails>
    {
        private readonly ApplicationdbContext _context;
        public OrderDetailsRepository(ApplicationdbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(OrderDetails entity)
        {
            await _context.OrderDetails.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if(orderDetails != null) 
            {
                 _context.OrderDetails.Remove(orderDetails);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public Task<IEnumerable<OrderDetails>> FindAllAsync(Func<OrderDetails, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> FindAsync(Expression<Func<OrderDetails, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();

        }

        public Task<OrderDetails> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDetails> GetByIdAsync(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                return orderDetails;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public Task<OrderDetails> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(OrderDetails entity)
        {
             _context.OrderDetails.Update(entity);
        }
    }
}
