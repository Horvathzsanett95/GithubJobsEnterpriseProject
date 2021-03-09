using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;

namespace GithubJobsEnterpriseProject.Tests
{
    class LoginServiceTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        public static GithubJobsContext InitContext()
        {
            
            var options = new DbContextOptionsBuilder<GithubJobsContext>()
            .UseInMemoryDatabase(databaseName: "JobDatabase")
            .Options;
            var context = new GithubJobsContext(options);
            return context;
        }

        [Test] 
        public void LoginReturnsTrueWithValidCredentialsTest()
        {
            var context = InitContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            User user = new User("username", "password", "email@gmail.com");
            context.Add(user);
            context.SaveChanges();
            var substitude = Substitute.For<IPasswordHandlerService>();
            substitude.PasswordValidator(Arg.Any<string>(), Arg.Any<string>()).Returns(true);
            LoginService service = new LoginService(context, substitude);
            bool result = service.Login("username", "password");
            Assert.IsTrue(result);
        }
    }
}
