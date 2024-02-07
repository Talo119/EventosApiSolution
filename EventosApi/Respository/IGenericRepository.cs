namespace EventosApi.Respository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task<T> PostAsync(T item);
        Task<bool> PutAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
    }
}
