using System.Collections.Generic;

namespace GithubJobsEnterpriseProject.Models.Repositories
{
    public class JobRepository : Repository<GithubJob>, IJobRepository
    {
        public JobRepository(GithubJobsContext context)
            :base(context)
        {
            
        }
        public GithubJobsContext GithubJobsContext { get { return _context as GithubJobsContext; } }
        public void BindJobsWithRatings(IEnumerable<Rating> ratings)
        {
            foreach (var job in GithubJobsContext.JobItems)
            {
                foreach (var rating in ratings)
                {
                    if (rating.UserId == job.Id)
                    {
                        job.Ratings.Add(rating);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
