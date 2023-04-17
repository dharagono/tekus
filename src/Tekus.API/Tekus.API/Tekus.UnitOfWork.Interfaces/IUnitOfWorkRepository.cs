using Tekus.Repository.Interfaces;

namespace Tekus.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IVendorRepository VendorRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IVendorCustomsRepository VendorCustomsRepository { get; }
        IServicePortafolioRepository ServicePortafolioRepository { get; }
        ICountryRepository CountryRepository { get; }
    }
}
