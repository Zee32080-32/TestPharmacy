using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class FeedbackFormRepository : IRepository<FeedbackForm>
    {
        private readonly ApplicationdbContext _context;

        public FeedbackFormRepository(ApplicationdbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(FeedbackForm entity)
        {
            var add =  _context.FeedbackForm.Add(entity);
            await _context.SaveChangesAsync();
            //return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var findForm = await _context.FeedbackForm.FindAsync(id);
            if (findForm == null) 
            {
                throw new Exception();
            }
            _context.Remove(findForm);    
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<FeedbackForm>> FindAllAsync(Func<FeedbackForm, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<FeedbackForm> FindAsync(Expression<Func<FeedbackForm, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FeedbackForm>> GetAllAsync()
        {
            return await _context.FeedbackForm.ToListAsync();
            
        }

        public Task<FeedbackForm> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<FeedbackForm> GetByIdAsync(int id)
        {
            var find = await _context.FeedbackForm.FindAsync(id);
            if (find != null)
            {
                throw new Exception();
            }
            return find;

        }

        public Task<FeedbackForm> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(FeedbackForm entity)
        {
            var update =  _context.FeedbackForm.Update(entity); 
            await _context.SaveChangesAsync();
        }


    }
}
