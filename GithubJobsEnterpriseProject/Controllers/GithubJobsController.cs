using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GithubJobsEnterpriseProject.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace GithubJobsEnterpriseProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class GithubJobsController : ControllerBase, IGitHubJobsController
    {
        private readonly JobContext _context;

        public GithubJobsController(JobContext context)
        {
            
            _context = context;
            

        }

        // GET: api/GithubJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GithubJob>>> GetJobItems()
        {
            var items = _context.JobItems;
            if (items != null)
            {
                _context.RemoveRange(_context.JobItems);
            }
            
            GithubJobsApiCallController controller = new GithubJobsApiCallController();
            IEnumerable<GithubJob> GithubJobs = controller.GetGithubJobsFromUrl();

            foreach (GithubJob job in GithubJobs)
            {
                _context.JobItems.AddRange(job);
                _context.SaveChanges();
            }
            return await _context.JobItems.ToListAsync();
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
    }
}
