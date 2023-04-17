using Microsoft.EntityFrameworkCore;
using Tekus.Models;
using Tekus.Repository.Interfaces;

namespace Tekus.Repository.SQLSERVER
{
    public class VendorRepository : IVendorRepository
    {
        private readonly RepositoryContext _repository;

        public VendorRepository(RepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(Vendor model)
        {
            try
            {
                var result = await _repository.Vendors.AddAsync(model);
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

        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            try
            {
                return await _repository.Vendors.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Vendor> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.Vendors.FirstOrDefaultAsync(column => column.Id == id);
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

        public async Task<string> GetVendorName(int id)
        {
             try
            {
                var result = await _repository.Vendors.FirstOrDefaultAsync(column => column.Id == id);
                if(result != null)
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

        public bool Update(Vendor model)
        {
            try
            {
                var result = _repository.Vendors.Update(model);
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
