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
        private readonly IEmailSenderService _emailService;
        private readonly ILoginService _loginService;
        private readonly IUnitOfWork _unit;
             
        public GithubJobsController(
            IJobApiService apiService, 
            IEmailSenderService emailService, 
            ILoginService loginService,
            IUnitOfWork unit)
        {
            _apiService = apiService;
            _emailService = emailService;
            _loginService = loginService;
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
        public async Task<ActionResult<GithubJob>> GetGithubJob(string id)
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
            var items = _unit.Jobs.GetAll();
            if (items != null)
            {
                _unit.Jobs.RemoveRange(items);
            }
            IEnumerable<GithubJob> GithubJobs = _apiService.GetGithubJobsByParameters(description, location);


            _unit.Jobs.AddRange(GithubJobs);
            _unit.Complete();
            return _unit.Jobs.GetAll();
        }

        [HttpPost("/registration")]
        public ActionResult GetCredentials()
        {
            var username = Request.Form["Username"];
            var email = Request.Form["Email"];
            var password = Request.Form["Password"];
            var hashedPassword = PasswordOperations.HashUserGivenPassword(password);
            User user = new User(username, email, hashedPassword);
            _unit.Users.Add(user);
            _unit.Complete();
            _emailService.SendEmail(email);

            return Redirect("/");
        }


        [HttpPost("/login")]
        public ActionResult GetLoginCredentials()
        {

            var username = Request.Form["Username"];
            var password = Request.Form["Password"];
            bool isLogged = _loginService.Login(username, password);
            Console.WriteLine(isLogged);
            if(isLogged)
            {

            }
            return NoContent();

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
        public ActionResult SaveFormToDb()
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


    }

   
}
