using GithubJobsEnterpriseProject.Models.Repositories;
using System;

namespace GithubJobsEnterpriseProject.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        IRatingRepository Ratings { get; }
        int Complete();
    }
}
