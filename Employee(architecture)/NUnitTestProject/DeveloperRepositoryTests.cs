using AutoMapper;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Repositories.Developers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace NUnitTestProject
{
    public class Tests
    {
        private DeveloperRepository _developerRepository;
        private Mock<IMapper> _mapper;
        private Mock<ILogger<DeveloperRepository>> _logger;
        private DbContextOptionsBuilder<CompanyContext> _options;

            
            

    [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<DeveloperRepository>>();
            _options = new DbContextOptionsBuilder<CompanyContext>()
               .UseInMemoryDatabase("gets_all");
           // var context = new CompanyContext(_options);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}