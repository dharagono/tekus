using Tekus.Models;
using Tekus.Repository.Interfaces.Actions;

namespace Tekus.Repository.Interfaces
{
    public interface IServiceRepository : IReadRepository<Service,int>, ICreateRepository<Service,bool>, IUpdateRepository<Service,bool>
    {
        Task<string> GetServiceName(int id);
    }
}
