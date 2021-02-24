using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Services
{
    public interface IEmailSenderService
    {
        public void SendEmail(string registeredEmail);
    }
}
