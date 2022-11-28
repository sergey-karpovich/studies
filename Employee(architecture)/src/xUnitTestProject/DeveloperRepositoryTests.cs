using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Repositories.Developers;
using Microsoft.EntityFrameworkCore;

namespace xUnitTestProject
{
    public class DeveloperRepositoryTests
    {
        [Fact]
        public void DeveloperRepository_GetAllDeveloper_GivenServiceResponseTheyExist()
        {
            var options = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase("gets_all").Options;

            
            using var context = new CompanyContext(options);


            //var repository = new DeveloperRepository(context,);
        }
    }
}