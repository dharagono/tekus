using Microsoft.EntityFrameworkCore;
using Tekus.Models;
using Tekus.Repository.Interfaces;

namespace Tekus.Repository.SQLSERVER
{
    public class ServicePortafolioRepository : IServicePortafolioRepository
    {
        private readonly RepositoryContext _repository;

        public ServicePortafolioRepository(RepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(ServicePortafolio model)
        {
            try
            {
                var result = await _repository.ServicePortafolios.AddAsync(model);
                if(result.State == EntityState.Added)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ServicePortafolio>> GetAllAsync()
        {
            try
            {
                return await _repository.ServicePortafolios.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ServicePortafolio>> GetByCountryId(int id)
        {
            try
            {
                return await _repository.ServicePortafolios.Where(column=>column.IdCountry==id).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServicePortafolio> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.ServicePortafolios.FirstOrDefaultAsync(column=>column.Id==id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ServicePortafolio>> GetByServiceId(int id)
        {
            try
            {
                return await _repository.ServicePortafolios.Where(column => column.IdService == id).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ServicePortafolio>> GetByVendorId(int id)
        {
            try
            {
                return await _repository.ServicePortafolios.Where(column => column.IdVendor == id).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ServicePortafolio model)
        {
            try
            {
                var result = _repository.ServicePortafolios.Update(model);
                if (result.State == EntityState.Modified)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
