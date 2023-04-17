using Tekus.Models;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.Services
{
    public interface ICountryServices
    {
        Task<IEnumerable<ResponseCountry>> GetAllCountrys();
        Task<bool> CreateCountry(Country Country);
        Task<ResponseCountry> GetByIdAsync(int id);
    }
    public class CountryServices : ICountryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCountry(Country Country)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    if(await context.Repositories.CountryRepository.CreateAsync(Country))
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

        public async Task<IEnumerable<ResponseCountry>> GetAllCountrys()
        {
            try
            {
                using(var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.CountryRepository.GetAllAsync();
                    if(result.Count() > 0)
                    {
                        return result.Select(column=> new ResponseCountry { Id=column.Id,Name=column.Name,Code=column.Code});
                    }
                    return null;
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<ResponseCountry> GetByIdAsync(int id)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = await context.Repositories.CountryRepository.GetByIdAsync(id);
                    if (result != null)
                    {
                        return new ResponseCountry
                        {
                            Id=result.Id,Name=result.Name,Code=result.Code
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