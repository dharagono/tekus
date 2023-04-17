using Tekus.DTO;
using Tekus.Models;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.Services
{
    public interface IVendorServices
    {
        Task<IEnumerable<ResponseVendor>> GetAllVendors();
        Task<bool> CreateVendor(Vendor vendor);
        bool UpdateVendor(Vendor vendor);
        Task<ResponseVendor> GetByIdAsync(int id);
    }
    public class VendorServices : IVendorServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateVendor(Vendor vendor)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if(await context.Repositories.VendorRepository.CreateAsync(vendor))
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

        public async Task<IEnumerable<ResponseVendor>> GetAllVendors()
        {
            try
            {
                using(var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.VendorRepository.GetAllAsync();
                    if(result.Count() > 0)
                    {
                        return result.Select(column=> new ResponseVendor() {Id=column.Id, Name=column.Name, Nit=column.Nit, Email=column.Email });
                    }
                    return null;
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public bool UpdateVendor(Vendor vendor)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if (context.Repositories.VendorRepository.Update(vendor))
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

        public async Task<ResponseVendor> GetByIdAsync(int id)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.VendorRepository.GetByIdAsync(id);
                    if(result != null)
                    {
                        return new ResponseVendor()
                        {
                            Id = result.Id,
                            Name = result.Name,
                            Nit = result.Nit,
                            Email = result.Email
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
    }
}