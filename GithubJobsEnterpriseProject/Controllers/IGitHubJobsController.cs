using GithubJobsEnterpriseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    interface IGitHubJobsController 
    {
        public IEnumerable<GithubJob> GetJobItems();
        public Task<ActionResult<GithubJob>> GetGithubJob(string id);
    }
}
