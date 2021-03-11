using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Tests
{
    class JobRepositoryTests
    {
        public static GithubJobsContext InitContext()
        {

            var options = new DbContextOptionsBuilder<GithubJobsContext>()
            .UseInMemoryDatabase(databaseName: "JobDatabase")
            .Options;
            var context = new GithubJobsContext(options);
            return context;
        }

        [Test]
        public void BindJobsWithRatingsAddsRatingToExistingJob()
        {
            var context = InitContext();
            JobRepository repository = new JobRepository(context);
            AddJobsToContext(repository);
            var ratings = GetTestRatings();
            repository.BindJobsWithRatings(ratings);
            var jobToTest = repository.Get("1");
            var rating = jobToTest.Ratings;
            Assert.AreEqual(jobToTest.Ratings.Count, 1);
        }

        [Test]
        public void GetJobByParametersReturnsValueWithValidInputs()
        {
            var context = InitContext();
            JobRepository repository = new JobRepository(context);
            AddJobsToContext(repository);
            var result = repository.GetJobByParameters("java", "Remote");
            Assert.AreEqual(result.Count(), 1);
        }
        
        [Test]
        public void GetJobByTechnologyReturnsNotNullWIthValidParameter()
        {
            var context = InitContext();
            JobRepository repository = new JobRepository(context);
            AddJobsToContext(repository);
            int result = repository.GetJobByTechnology("java");
            Assert.AreEqual(result, 2);
        }

        public void AddJobsToContext(Repository<GithubJob> repository)
        {
            var result = GetTestJobs();
            repository.AddRange(result);
        }

        public List<GithubJob> GetTestJobs()
        {
            List<GithubJob> jobs = new List<GithubJob>
            {
                new GithubJob
                {
                    Id = "1",
                    Description = "java job",
                    Title = "Java job",
                    Location = "Remote"
                },
                new GithubJob
                {
                    Id = "2",
                    Description = "java opportunity with devops",
                    Title = "Junior position",
                    Location = "Budapest"
                },
            };
            return jobs;
        }

        public List<Rating> GetTestRatings()
        {
            List<Rating> ratings = new List<Rating>
            {
                new Rating
                {
                    Id = "66",
                    RatingValue = 3,
                    UserId = "1"
                },
                new Rating
                {
                    Id = "67",
                    RatingValue = 5,
                    UserId = "1"
                }
            };
            return ratings;
        }


    }
}
