using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Services;
using GithubJobsEnterpriseProject.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class GithubJobsController : ControllerBase, IGitHubJobsController
    {
        private readonly JobContext _context;
        private readonly IJobApiService _apiService;
        private readonly IEmailSenderService _emailService;
        private readonly IPasswordHandlerService _passwordService;
        private readonly ILoginService _loginService;
             
        public GithubJobsController(JobContext context, 
            IJobApiService apiService, 
            IEmailSenderService emailService, 
            IPasswordHandlerService passwordService,
            ILoginService loginService)
        {

            _context = context;
            _apiService = apiService;
            _emailService = emailService;
            _passwordService = passwordService;
            _loginService = loginService;
        }

        // GET: api/GithubJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GithubJob>>> GetJobItems()
        {

            GetJobs();
            return await _context.JobItems.ToListAsync();
        }

        public void GetJobs()
        {
            IEnumerable<GithubJob> GithubJobs = _apiService.GetGithubJobsFromUrl();

            foreach (GithubJob job in GithubJobs)
            {
                //_context.JobItems.UpdateRange(job);
                foreach (Rating rating in _context.Rating)
                {
                    if (rating.UserId == job.Id)
                    {
                        job.Ratings.Add(rating);
                        _context.SaveChanges();
                    }
                }

            }


        }

        // GET: api/GithubJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GithubJob>> GetGithubJob(string id)
        {
            var githubJob = await _context.JobItems.FindAsync(id);

            if (githubJob == null)
            {
                return NotFound();
            }

            return githubJob;
        }

        [HttpGet("description={description}&location={location}")]
        public async Task<ActionResult<IEnumerable<GithubJob>>> GetGithubJobByDescriptionAndPlace([FromRoute] string description,
                                                                                                  [FromRoute] string location)
        {
            var items = _context.JobItems;
            if (items != null)
            {
                _context.RemoveRange(_context.JobItems);
            }
            IEnumerable<GithubJob> GithubJobs = _apiService.GetGithubJobsByParameters(description, location);

            foreach (GithubJob job in GithubJobs)
            {
                _context.JobItems.AddRange(job);
                _context.SaveChanges();
            }
            return await _context.JobItems.ToListAsync();
        }




        // PUT: api/GithubJobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGithubJob(string id, GithubJob githubJob)
        {
            if (id != githubJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(githubJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GithubJobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GithubJobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GithubJob>> PostGithubJob(GithubJob githubJob)
        {
            _context.JobItems.Add(githubJob);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GithubJobExists(githubJob.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGithubJob", new { id = githubJob.Id }, githubJob);
        }

        // DELETE: api/GithubJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGithubJob(string id)
        {
            var githubJob = await _context.JobItems.FindAsync(id);
            if (githubJob == null)
            {
                return NotFound();
            }

            _context.JobItems.Remove(githubJob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GithubJobExists(string id)
        {
            return _context.JobItems.Any(e => e.Id == id);
        }

        [HttpPost("/registration")]
        public ActionResult GetCredentials()
        {
            var username = Request.Form["Username"];
            var email = Request.Form["Email"];
            var password = Request.Form["Password"];
            var hashedPassword = _passwordService.HashUserGivenPassword(password);
            User user = new User(username, email, hashedPassword);
            _context.Users.Add(user);
            _context.SaveChanges();
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
            

            return NoContent();

        }

        [HttpPost("/add-rating")]
        public ActionResult AddRatingToDatabase(Rating rating)
        {

            rating.Id = IdGenerator.IdStringGenerator();
            foreach (var job in _context.JobItems)
            {
                if (job.Id == rating.UserId)
                {
                    job.Ratings.Add(rating);
                }
            }
            _context.SaveChanges();
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
            _context.JobItems.Add(job);
            _context.SaveChanges();

            return NoContent();

        }


    }

   
}
