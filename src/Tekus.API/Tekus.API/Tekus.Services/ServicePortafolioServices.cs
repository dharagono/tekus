using Tekus.DTO;
using Tekus.Models;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.Services
{
    public interface IServicePortafolioServices
    {
        Task<IEnumerable<ResponseServicePortafolio>> GetAllServicePortafolio();
        Task<bool> CreateServicePortafolio(ServicePortafolio servicePortafolio);
        bool UpdateServicePortafolio(ServicePortafolio servicePortafolio);
        Task<ResponseServicePortafolio> GetByIdAsync(int id);
        Task<IEnumerable<ResponseServicePortafolio>> GetByVendorId(int vendorId);
        Task<IEnumerable<ResponseServicePortafolio>> GetByCountryId(int countryId);
        Task<IEnumerable<ResponseServicePortafolio>> GetByServiceId(int serviceId);
    }
    public class ServicePortafolioServices : IServicePortafolioServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicePortafolioServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateServicePortafolio(ServicePortafolio servicePortafolio)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if(await context.Repositories.ServicePortafolioRepository.CreateAsync(servicePortafolio))
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

        public async Task<IEnumerable<ResponseServicePortafolio>> GetAllServicePortafolio()
        {
            try
            {
                using(var context = _unitOfWork.Create())
                {
                    var portafolio = await context.Repositories.ServicePortafolioRepository.GetAllAsync();
                    if (portafolio != null)
                    {
                        List<ResponseServicePortafolio> result = new();
                        foreach (var service in portafolio)
                        {
                            result.Add(new ResponseServicePortafolio
                            {
                                Id = service.Id,
                                VendorName = await context.Repositories.VendorRepository.GetVendorName(service.IdVendor),
                                ServiceName =  await context.Repositories.ServiceRepository.GetServiceName(service.IdService),
                                CountryCode = await context.Repositories.CountryRepository.GetCountryCode(service.IdCountry),
                                Status = service.Status == true ? "Available " : "unavailable"
                            });
                        }
                        if(result.Count() > 0)
                        {
                            return result;
                        }
                    }
                    return null;
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public bool UpdateServicePortafolio(ServicePortafolio servicePortafolio)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if (context.Repositories.ServicePortafolioRepository.Update(servicePortafolio))
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

        public async Task<ResponseServicePortafolio> GetByIdAsync(int id)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.ServicePortafolioRepository.GetByIdAsync(id);
                    if (result != null)
                    {
                        return new ResponseServicePortafolio()
                            {
                                Id = result.Id,
                                VendorName = await context.Repositories.VendorRepository.GetVendorName(result.IdVendor),
                                ServiceName = await context.Repositories.ServiceRepository.GetServiceName(result.IdService),
                                CountryCode = await context.Repositories.CountryRepository.GetCountryCode(result.IdCountry),
                                Status = result.Status == true ? "Available " : "unavailable"
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

        public async Task<IEnumerable<ResponseServicePortafolio>> GetByVendorId(int vendorId)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var portafolio = await context.Repositories.ServicePortafolioRepository.GetByVendorId(vendorId);
                    if (portafolio != null)
                    {
                        List<ResponseServicePortafolio> result = new();
                        foreach (var service in portafolio)
                        {
                            result.Add(new ResponseServicePortafolio
                            {
                                Id = service.Id,
                                VendorName = await context.Repositories.VendorRepository.GetVendorName(service.IdVendor),
                                ServiceName = await context.Repositories.ServiceRepository.GetServiceName(service.IdService),
                                CountryCode = await  context.Repositories.CountryRepository.GetCountryCode(service.IdCountry),
                                Status = service.Status == true ? "Available " : "unavailable"
                            });
                        }
                        if (result.Count() > 0)
                        {
                            return result;
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ResponseServicePortafolio>> GetByCountryId(int countryId)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var portafolio = await context.Repositories.ServicePortafolioRepository.GetByCountryId(countryId);
                    if (portafolio != null)
                    {
                        List<ResponseServicePortafolio> result = new();
                        foreach (var service in portafolio)
                        {
                            result.Add(new ResponseServicePortafolio
                            {
                                Id = service.Id,
                                VendorName = await context.Repositories.VendorRepository.GetVendorName(service.IdVendor),
                                ServiceName = await context.Repositories.ServiceRepository.GetServiceName(service.IdService),
                                CountryCode = await context.Repositories.CountryRepository.GetCountryCode(service.IdCountry),
                                Status = service.Status == true ? "Available " : "unavailable"
                            });
                        }
                        if (result.Count() > 0)
                        {
                            return result;
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ResponseServicePortafolio>> GetByServiceId(int serviceId)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var portafolio = await context.Repositories.ServicePortafolioRepository.GetByServiceId(serviceId);
                    if (portafolio != null)
                    {
                        List<ResponseServicePortafolio> result = new();
                        foreach (var service in portafolio)
                        {
                            result.Add(new ResponseServicePortafolio
                            {
                                Id = service.Id,
                                VendorName = await context.Repositories.VendorRepository.GetVendorName(service.IdVendor),
                                ServiceName = await context.Repositories.ServiceRepository.GetServiceName(service.IdService),
                                CountryCode = await context.Repositories.CountryRepository.GetCountryCode(service.IdCountry),
                                Status = service.Status == true ? "Available " : "unavailable"
                            });
                        }
                        if (result.Count() > 0)
                        {
                            return result;
                        }
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