using Microsoft.EntityFrameworkCore;
using Tekus.Models;
using Tekus.Repository.Interfaces;

namespace Tekus.Repository.SQLSERVER
{
    public class VendorCustomsRepository : IVendorCustomsRepository
    {
        private readonly RepositoryContext _repository;

        public VendorCustomsRepository(RepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(VendorCustom model)
        {
            try
            {
                var result = await _repository.VendorCustoms.AddAsync(model);
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

        public async Task<IEnumerable<VendorCustom>> GetAllAsync()
        {
            try
            {
                return await _repository.VendorCustoms.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VendorCustom> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.VendorCustoms.FirstOrDefaultAsync(column => column.Id == id);
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

        public async Task<IEnumerable<VendorCustom>> GetByVendorId(int id)
        {
            try
            {
                var result = await _repository.VendorCustoms.Where(column => column.IdVendor == id).ToListAsync();
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

        public bool Update(VendorCustom model)
        {
            try
            {
                var result = _repository.VendorCustoms.Update(model);
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
