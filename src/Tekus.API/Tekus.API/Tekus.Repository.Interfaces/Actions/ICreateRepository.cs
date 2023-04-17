namespace Tekus.Repository.Interfaces.Actions
{
    public interface ICreateRepository<X,Y> where X : class
    {
        Task<Y> CreateAsync(X model);
    }
}
