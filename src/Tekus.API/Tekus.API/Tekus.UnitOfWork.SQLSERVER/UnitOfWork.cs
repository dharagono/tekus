using Microsoft.Extensions.Configuration;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.UnitOfWork.SQLSERVER
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IUnitOfWorkAdapter Create()
        {
            string connectionString = _configuration.GetConnectionString("SQLServerConnectionString");
            return new UnitOfWorkAdapter(connectionString);
        }
    }
}
