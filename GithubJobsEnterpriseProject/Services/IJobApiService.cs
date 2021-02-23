using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Services
{
    public interface IJobApiService
    {
        public Appsettings GetLink();
        public IEnumerable<GithubJob> GetGithubJobsFromUrl();
        public IEnumerable<GithubJob> GetGithubJobsByParameters(string descriptionParameter, string locationParameter);

    }
}
