using Tekus.Models;
using Tekus.Repository.Interfaces.Actions;

namespace Tekus.Repository.Interfaces
{
    public interface IServicePortafolioRepository : IReadRepository<ServicePortafolio,int>, ICreateRepository<ServicePortafolio,bool>, IUpdateRepository<ServicePortafolio,bool>
    {
        Task<IEnumerable<ServicePortafolio>> GetByVendorId(int id);
        Task<IEnumerable<ServicePortafolio>> GetByServiceId(int id);
        Task<IEnumerable<ServicePortafolio>> GetByCountryId(int id);
    }
}
