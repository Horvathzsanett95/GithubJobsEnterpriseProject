using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using GithubJobsEnterpriseProject.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class GithubJobsController : ControllerBase, IGitHubJobsController
    {
        private readonly IJobApiService _apiService;

        private readonly IUnitOfWork _unit;
             
        public GithubJobsController(
            IJobApiService apiService, 
            
            IUnitOfWork unit)
        {
            _apiService = apiService;
            
            _unit = unit;
        }

        // GET: api/GithubJobs
        [HttpGet]
        public IEnumerable<GithubJob> GetJobItems()
        {


            IEnumerable<Rating> ratings = _unit.Ratings.GetAll();
            _unit.Jobs.BindJobsWithRatings(ratings);
            return _unit.Jobs.GetAll();
        }


        // GET: api/GithubJobs/5
        [HttpGet("{id}")]
        public ActionResult<GithubJob> GetGithubJob(string id)
        {
            var githubJob = _unit.Jobs.Get(id);

            if (githubJob == null)
            {
                return NotFound();
            }

            return githubJob;
        }

        [HttpGet("description={description}&location={location}")]
        public IEnumerable<GithubJob> GetGithubJobByDescriptionAndPlace([FromRoute] string description,
                                                                        [FromRoute] string location)
        {
            return _unit.Jobs.GetJobByParameters(description, location);
        }
        

        [HttpPost("/add-rating")]
        public ActionResult AddRatingToDatabase(Rating rating)
        {

            rating.Id = IdGenerator.IdStringGenerator();
            _unit.Ratings.Add(rating);
            _unit.Complete();
            return NoContent();

        }

        [HttpPost("/hire-form")]
        public ActionResult SaveNewJobFromForm()
        {
            GithubJob job = new GithubJob();
            job.Id = IdGenerator.IdStringGenerator();
            job.Type = Request.Form["Type"];
            job.Company = Request.Form["Company"];
            job.Location = Request.Form["Location"];
            job.Title = Request.Form["Title"];
            job.Description = Request.Form["Description"];
            job.HowToApply = Request.Form["HowToApply"];
            job.CompanyUrl = Request.Form["CompanyUrl"];
            _unit.Jobs.Add(job);
            _unit.Complete();
            return Redirect("/");

        }

        [HttpGet("/statistics/keyword={technology}")]
        public int GetJobByTechnology(string technology)
        {
            return _unit.Jobs.GetJobByTechnology(technology);
        }


    }

   
}
