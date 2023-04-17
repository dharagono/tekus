using Tekus.Repository.Interfaces;
using Tekus.Repository.SQLSERVER;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.UnitOfWork.SQLSERVER
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IVendorRepository VendorRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IServicePortafolioRepository ServicePortafolioRepository { get; }
        public IVendorCustomsRepository VendorCustomsRepository { get; }

        public UnitOfWorkRepository(RepositoryContext repository)
        {
            VendorRepository = new VendorRepository(repository);
            ServiceRepository = new ServiceRepository(repository);
            VendorCustomsRepository =new VendorCustomsRepository(repository);
            ServicePortafolioRepository=new ServicePortafolioRepository(repository);
            CountryRepository = new CountryRepository(repository);
        }
    }
}