using GithubJobsEnterpriseProject.Models;
using System.Collections.Generic;

namespace GithubJobsEnterpriseProject.Services
{
    public interface IJobApiService
    {
        public Appsettings GetLink();
        public IEnumerable<GithubJob> GetGithubJobsFromUrl();

    }
}
