using System.Collections.Generic;

namespace GithubJobsEnterpriseProject.Models.Repositories
{
    public interface IJobRepository : IRepository<GithubJob>
    {
        void BindJobsWithRatings(IEnumerable<Rating> ratings);
        IEnumerable<GithubJob> GetJobByParameters(string descriptionParameter, string locationParameter);
        int GetJobByTechnology(string technology);
    }
}
