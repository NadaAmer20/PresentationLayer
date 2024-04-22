//sing PresentationLayer.DTO;
namespace BusinessLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task Add(T entity);
        public Task Update(T entity);
        public Task DeleteAsync(int id);


    }
}
