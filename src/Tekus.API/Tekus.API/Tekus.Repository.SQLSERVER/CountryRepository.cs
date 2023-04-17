using Microsoft.EntityFrameworkCore;
using Tekus.Models;
using Tekus.Repository.Interfaces;

namespace Tekus.Repository.SQLSERVER
{
    public class CountryRepository : ICountryRepository
    {
        private readonly RepositoryContext _repository;

        public CountryRepository(RepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(Country model)
        {
            try
            {
                var result = await _repository.Countries.AddAsync(model);
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

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            try
            {
                return await _repository.Countries.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.Countries.FirstOrDefaultAsync(column => column.Id == id);
                if (result != null)
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

        public async Task<string> GetCountryCode(int id)
        {
            var result = await _repository.Countries.FirstOrDefaultAsync(column => column.Id == id);
            if (result != null)
            {
                return result.Code;
            }
            return null;
        }

        public bool Update(Country model)
        {
            try
            {
                var result = _repository.Countries.Update(model);
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
