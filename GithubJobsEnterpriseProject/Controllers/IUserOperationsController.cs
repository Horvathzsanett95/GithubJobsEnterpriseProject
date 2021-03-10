using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    interface IUserOperationsController
    {
        ActionResult RegisterNewUser();
        ActionResult GetLoginCredentials();
    }
}
