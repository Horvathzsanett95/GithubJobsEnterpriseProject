using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    public interface IAppsettingsController
    {
        public Appsettings GetLink();
    }
}
