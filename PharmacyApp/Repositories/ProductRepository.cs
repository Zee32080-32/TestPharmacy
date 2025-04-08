using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class ProductRepository : IRepository<Products>
    {
        private readonly ApplicationdbContext _context;
        public ProductRepository(ApplicationdbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Products entity)
        {

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Products = await _context.Products.FindAsync(id);
            if (Products == null)
            {
                throw new Exception();
            }
            _context.Products.Remove(Products);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Products>> FindAllAsync(Func<Products, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Products> FindAsync(Expression<Func<Products, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Products> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            var Products = await _context.Products.FindAsync(id);
            if (Products == null)
            {
                throw new KeyNotFoundException();
            }
            return Products;
        }

        public async Task<Products> GetByNameAsync(string name)
        {
            var productname = await _context.Products.FirstOrDefaultAsync(p => p.ProductName == name);
            if (productname == null)
            {
                throw new Exception();
            }
            return productname;
        }


        public async Task UpdateAsync(Products entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
