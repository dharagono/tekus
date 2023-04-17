using Tekus.Models;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.Services
{
    public interface IServiceServices
    {
        Task<IEnumerable<ResponseService>> GetAllServices();
        Task<bool> CreateService(Service Service);
        bool UpdateService(Service Service);
        Task<ResponseService> GetByIdAsync(int id);
    }
    public class ServiceServices : IServiceServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateService(Service service)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if(await context.Repositories.ServiceRepository.CreateAsync(service))
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

        public async Task<IEnumerable<ResponseService>> GetAllServices()
        {
            try
            {
                using(var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.ServiceRepository.GetAllAsync();
                    if(result.Count() > 0)
                    {
                        return result.Select(column=>new ResponseService { Id=column.Id,Name=column.Name,Hourprice=column.Hourprice});
                    }
                    return null;
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public bool UpdateService(Service Service)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if (context.Repositories.ServiceRepository.Update(Service))
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

        public async Task<ResponseService> GetByIdAsync(int id)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.ServiceRepository.GetByIdAsync(id);
                    if (result != null)
                    {
                        return new ResponseService
                        {
                            Id = result.Id, Name = result.Name, Hourprice = result.Hourprice
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