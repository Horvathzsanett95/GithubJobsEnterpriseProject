using GithubJobsEnterpriseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    public class AppsettingsController : ControllerBase, IAppsettingsController
    {
        private readonly IConfiguration _config;

        public AppsettingsController(IConfiguration iconfig)
        {
            _config = iconfig;
        }

        public Appsettings GetLink()
        {
            Appsettings appsettings = new Appsettings();
            appsettings.url = _config.GetValue<string>("GithubJobs:Url");
            appsettings.plainUrl = _config.GetValue<string>("GithubJobs:PlainUrl");
            return appsettings;
        }
    }
}
