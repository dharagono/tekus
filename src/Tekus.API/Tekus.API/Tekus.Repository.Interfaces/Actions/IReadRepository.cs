namespace Tekus.Repository.Interfaces.Actions
{
    public interface IReadRepository<X,Y> where X : class
    {
        Task<X> GetByIdAsync(Y id);
        Task<IEnumerable<X>> GetAllAsync();
    }
}
