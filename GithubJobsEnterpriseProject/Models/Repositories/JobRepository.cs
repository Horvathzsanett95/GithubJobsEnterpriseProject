using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<GithubJob> GetJobByParameters(string descriptionParameter, string locationParameter)
        {
            var result = GithubJobsContext.JobItems.Where(x => x.Description.Contains(descriptionParameter));
                
            var final = result.Where(job => job.Location.Contains(locationParameter))
                .ToList();
            Console.WriteLine(descriptionParameter);
            Console.WriteLine(locationParameter);
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
            return final;
        }

        public int GetJobByTechnology(string technology)
        {
            return GithubJobsContext.JobItems.Where(x => x.Description.Contains(technology)).Count();
        }
    }
}
