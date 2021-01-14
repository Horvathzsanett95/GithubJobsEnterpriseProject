using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubJobsEnterpriseProject.Controllers;
using GithubJobsEnterpriseProject.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace GithubJobsEnterpriseProject.Tests.ControllerTests
{
    class GithubJobsControllerTests
    {
        [Test]
        public void GetJobItemsReturnValueTypeTest()
        {
            JobContext context = Substitute.For<JobContext>();
            IJobApiService service = Substitute.For<IJobApiService>();
            GithubJobsController controller = new GithubJobsController(context, service);
            var result = controller.GetJobItems();
            Assert.That(result, Is.InstanceOf<GithubJob>());
        }
    }
}
