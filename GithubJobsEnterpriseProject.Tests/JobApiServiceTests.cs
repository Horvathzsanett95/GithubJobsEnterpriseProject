using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GithubJobsEnterpriseProject.Models;
using NSubstitute;
using NUnit.Framework;
using GithubJobsEnterpriseProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GithubJobsEnterpriseProject.Tests
{
    class JobApiServiceTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Test]
        public void GetLinkReturnValueCorrectTest()
        {
            var config = InitConfiguration();
            JobApiService jobApiService = new JobApiService(config);
            Assert.That(jobApiService.GetLink().Url, Is.EqualTo("https://jobs.github.com/positions.json"));
            Assert.That(jobApiService.GetLink().BaseUrl, Is.EqualTo("https://jobs.github.com/"));
        }
    }
}
