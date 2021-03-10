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
        IEnumerable<GithubJob> GetJobItems();
        ActionResult<GithubJob> GetGithubJob(string id);
        IEnumerable<GithubJob> GetGithubJobByDescriptionAndPlace([FromRoute] string description,
                                                                 [FromRoute] string location);
        ActionResult AddRatingToDatabase(Rating rating);
        ActionResult SaveNewJobFromForm();

    }
}
