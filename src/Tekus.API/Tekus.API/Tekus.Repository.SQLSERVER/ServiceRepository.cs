using Microsoft.EntityFrameworkCore;
using Tekus.Models;
using Tekus.Repository.Interfaces;

namespace Tekus.Repository.SQLSERVER
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly RepositoryContext _repository;

        public ServiceRepository(RepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(Service model)
        {
            try
            {
                var result = await _repository.Services.AddAsync(model);
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

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            try
            {
                return await _repository.Services.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.Services.FirstOrDefaultAsync(column => column.Id == id);
                if(result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetServiceName(int id)
        {
            try
            {
                var result = await _repository.Services.FirstOrDefaultAsync(column => column.Id == id);
                if (result != null)
                {
                    return result.Name;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Service model)
        {
            try
            {
                var result = _repository.Services.Update(model);
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
