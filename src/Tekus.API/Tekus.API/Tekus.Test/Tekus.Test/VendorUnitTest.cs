using Microsoft.EntityFrameworkCore;
using Tekus.Repository.SQLSERVER;
using Tekus.Services;
using Tekus.UnitOfWork.Interfaces;
using Tekus.UnitOfWork.SQLSERVER;

namespace Tekus.Test
{
    public class VendorUnitTest
    {
        private RepositoryContext _repository;
        private UnitOfWorkRepository _unitOfWork;
        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=tekussas;Trusted_Connection=True;");
            _repository = new(builder.Options);
            _unitOfWork = new(_repository);
        }

        [Test]
        public async Task GetTest()
        {
            Console.WriteLine("Testing - GetAllVendors Service - Waiting");
            var vendors = await _unitOfWork.VendorRepository.GetAllAsync();
            Assert.That(vendors , Is.Not.Null, "Tested - GetAllVendors - Failed");
            Console.WriteLine("Tested - GetAllVendors Service - OK");

            Console.WriteLine("Testing - GetAllServices Service - Waiting");
            var services = await _unitOfWork.ServiceRepository.GetAllAsync();
            Assert.That(vendors, Is.Not.Null, "Tested - GetAllServices - Failed");
            Console.WriteLine("Tested - GetAllServices Service - OK");

            Console.WriteLine("Testing - GetAllPortafolio Service - Waiting");
            var portafolio = await _unitOfWork.ServicePortafolioRepository.GetAllAsync();
            Assert.That(vendors, Is.Not.Null, "Tested - GetAllPortafolio - Failed");
            Console.WriteLine("Tested - GetAllPortafolio Service - OK");
        }

        [Test]
        public async Task PostTest()
        {
            Console.WriteLine("Testing - CreateVendor Service - Waiting");
            bool vendors = await _unitOfWork.VendorRepository.CreateAsync(new Models.Vendor { Name="Test Vendor", Nit="000-000-000", Email="Test@Test.Test"});
            Assert.That(vendors, Is.True, "Tested - CreateVendor - Failed");
            _repository.Dispose();
            Console.WriteLine("Tested - CreateVendor Service - OK");
        }
    }
}