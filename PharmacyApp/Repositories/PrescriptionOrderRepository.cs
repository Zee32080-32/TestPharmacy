using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class PrescriptionOrderRepository : IRepository<PrescriptionOrders>
    {
        private readonly ApplicationdbContext _context;

        public PrescriptionOrderRepository(ApplicationdbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PrescriptionOrders entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prescriptionOrder = await _context.PrescriptionOrders.FindAsync(id);
            if (prescriptionOrder == null)
            {
                throw new Exception();
            }
            _context.PrescriptionOrders.Remove(prescriptionOrder);
            await _context.SaveChangesAsync();

        }

        public Task<IEnumerable<PrescriptionOrders>> FindAllAsync(Func<PrescriptionOrders, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<PrescriptionOrders> FindAsync(Expression<Func<PrescriptionOrders, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PrescriptionOrders>> GetAllAsync()
        {
            return await _context.PrescriptionOrders.ToListAsync();
        }

        public Task<PrescriptionOrders> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<PrescriptionOrders> GetByIdAsync(int id)
        {

            var prescriptionOrder = await _context.PrescriptionOrders.FindAsync(id);
            if (prescriptionOrder == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return prescriptionOrder;
            }
        }

        public Task<PrescriptionOrders> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PrescriptionOrders entity)
        {
            _context.PrescriptionOrders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
