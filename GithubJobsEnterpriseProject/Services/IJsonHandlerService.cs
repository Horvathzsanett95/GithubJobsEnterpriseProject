using GithubJobsEnterpriseProject.Models;
using System.Collections.Generic;

namespace GithubJobsEnterpriseProject.Services
{
    public interface IJsonHandlerService
    {
        List<User> DeconvertUsersJson();
        void Save(User user);
    }
}