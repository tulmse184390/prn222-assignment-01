namespace DAL.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        void AddAsync(T entity);
        void Update(T entity);
        void DeleteAsync(int id);
        Task SaveAsync();
    }
}
