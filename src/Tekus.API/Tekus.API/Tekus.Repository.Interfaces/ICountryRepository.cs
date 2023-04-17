using Tekus.Models;
using Tekus.Repository.Interfaces.Actions;

namespace Tekus.Repository.Interfaces
{
    public interface ICountryRepository : IReadRepository<Country,int>, ICreateRepository<Country,bool>
    {
        Task<string> GetCountryCode(int id);
    }
}
