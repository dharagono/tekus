using Microsoft.EntityFrameworkCore;
using Tekus.Repository.SQLSERVER;
using Tekus.UnitOfWork.Interfaces;

namespace Tekus.UnitOfWork.SQLSERVER
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        protected readonly RepositoryContext _repository;
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkAdapter(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseSqlServer(connectionString);
            _repository = new(builder.Options);
            Repositories = new UnitOfWorkRepository(_repository);

        }

        public void Dispose()
        {
            _repository.Dispose();
            //Repositories = null;
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
