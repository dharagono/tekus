using Tekus.DTO;
using Tekus.Models;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.Services
{
    public interface IVendorCustomsServices
    {
        Task<bool> CreateVendorCustoms(VendorCustom vendorCustom);
        bool UpdateVendorCustoms(VendorCustom vendorCustom);
        Task<ResponseVendorCustoms> GetByIdAsync(int id);
        Task<IEnumerable<ResponseVendorCustoms>> GetByVendorId(int id);
    }
    public class VendorCustomsServices : IVendorCustomsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorCustomsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateVendorCustoms(VendorCustom vendorCustom)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if(await context.Repositories.VendorCustomsRepository.CreateAsync(vendorCustom))
                    {
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateVendorCustoms(VendorCustom vendorCustom)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if (context.Repositories.VendorCustomsRepository.Update(vendorCustom))
                    {
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseVendorCustoms> GetByIdAsync(int id)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.VendorCustomsRepository.GetByIdAsync(id);
                    if(result != null)
                    {
                        return new ResponseVendorCustoms
                        {
                            Id= result.Id,
                            Name=result.Name,
                            Value=result.Value,
                            IdVendor=result.IdVendor
                        };
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ResponseVendorCustoms>> GetByVendorId(int id)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.VendorCustomsRepository.GetByVendorId(id);
                    if (result.Count() > 0)
                    {
                        return result.Select(column=> new ResponseVendorCustoms { Id=column.Id, Name=column.Name, Value=column.Value, IdVendor=column.IdVendor });
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}