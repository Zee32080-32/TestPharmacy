namespace PharmacyApp.Services
{
    public interface IForm2Service<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> CreateAsync(T entity);   
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task<T> ReadOneAsync(int id);
     
    }
}
