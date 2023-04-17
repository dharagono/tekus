using Tekus.Models;
using Tekus.Repository.Interfaces.Actions;

namespace Tekus.Repository.Interfaces
{
    public interface IVendorRepository : IReadRepository<Vendor,int>, ICreateRepository<Vendor,bool>, IUpdateRepository<Vendor,bool>
    {
        Task<string> GetVendorName(int id);
    }
}
