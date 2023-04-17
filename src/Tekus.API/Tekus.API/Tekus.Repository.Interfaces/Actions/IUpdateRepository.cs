namespace Tekus.Repository.Interfaces.Actions
{
    public interface IUpdateRepository<X,Y> where X : class
    {
        Y Update(X model);
    }
}
