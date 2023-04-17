using Tekus.Models;
using Tekus.Repository.Interfaces.Actions;

namespace Tekus.Repository.Interfaces
{
    public interface IVendorCustomsRepository : IReadRepository<VendorCustom,int>, ICreateRepository<VendorCustom,bool>, IUpdateRepository<VendorCustom,bool>
    {
        Task<IEnumerable<VendorCustom>> GetByVendorId(int id);
    }
}
