using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class Form2Repository : IRepository<Form2>
    {
        private readonly ApplicationdbContext _context;

        public Form2Repository(ApplicationdbContext context)
        {
             _context = context;
        }
        public async Task AddAsync(Form2 entity)
        {
            await _context.form2s.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var form2 = await _context.form2s.FindAsync(id);
            if (form2 != null) 
            {
                throw new Exception();
            }

            _context.form2s.Remove(form2);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Form2>> FindAllAsync(Func<Form2, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Form2> FindAsync(Expression<Func<Form2, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Form2>> GetAllAsync()
        {
            return await _context.form2s.ToListAsync();

        }

        public Task<Form2> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Form2> GetByIdAsync(int id)
        {
            var form2 = await _context.form2s.FindAsync(id);
            if (form2 == null)
            {
                throw new Exception();
            }
            return form2;
        }

        public Task<Form2> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Form2 entity)
        {
            var change = _context.form2s.Update(entity);
            await _context.SaveChangesAsync();
        }






        /*

        // Fetch forms based on the CustomerId
        public async Task<IEnumerable<Form2>> GetByCustomerIdAsync(int customerId)
        {
            // Filter forms by the given CustomerId
            return await _context.Form2s.Where(f => f.CustomerId == customerId).ToListAsync();
        }

        public async Task AddAsync(Form2 form, int customerId)
        {
            // Assign the correct CustomerId to the form
            form.CustomerId = customerId;

            // Add the form to the database
            await _context.Form2s.AddAsync(form);
            await _context.SaveChangesAsync();
        }

        */

    }
}
