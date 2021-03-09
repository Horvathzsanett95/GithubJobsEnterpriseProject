﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Models.Repositories
{
    public interface IJobRepository : IRepository<GithubJob>
    {
        void BindJobsWithRatings(IEnumerable<Rating> ratings);
    }
}