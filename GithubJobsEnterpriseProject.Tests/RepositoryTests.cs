using GithubJobsEnterpriseProject.Models;
using GithubJobsEnterpriseProject.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GithubJobsEnterpriseProject.Tests
{
    class RepositoryTests
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
        public void AddWorkingWithOneElementAdded()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            Rating rating = new Rating();
            rating.Id = "5";
            rating.RatingValue = 4;
            rating.UserId = "11";
            repository.Add(rating);
            Assert.NotNull(context);
        }

        [Test]
        public void GetReturnsObjectWithValidInput()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            AddMultipleRatingsToContext(repository);
            Rating result = repository.Get("1");
            Assert.AreEqual(result.UserId, "1");
        }

        [Test]
        public void GetReturnsNullWhenContextIsEmpty()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            Rating result = repository.Get("-1");
            Assert.IsNull(result);
        }

        [Test]
        public void GetReturnsNullWithNotValidInput()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            AddMultipleRatingsToContext(repository);
            Rating result = repository.Get("-1");
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllReturnValueIsNotNullWithValidContext()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            AddMultipleRatingsToContext(repository);
            IEnumerable<Rating> ratings = repository.GetAll();
            Assert.AreEqual(ratings.Count(), 3);
        }

        [Test]
        public void RemoveWorksWithValidInput()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            Rating rating = new Rating();
            rating.Id = "5";
            rating.RatingValue = 4;
            rating.UserId = "11";
            repository.Add(rating);
            repository.Remove(rating);
            var result = repository.Get("1");
            Assert.IsNull(result);

        }

        [Test]
        public void RemoveRangeRemovesAllElementsFromContext()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            var ratings = GetTestRatings();
            repository.AddRange(ratings);
            repository.RemoveRange(ratings);
            Assert.IsNull(repository.Get("1"));
        }

        [Test]
        public void RemoveRangeRemovesValidInputList()
        {
            var context = InitContext();
            Repository<Rating> repository = new Repository<Rating>(context);
            var ratings = GetTestRatings();
            repository.AddRange(ratings);
            repository.Add(new Rating
            {
                Id = "33",
                RatingValue = 2,
                UserId = "7"
            });
            repository.RemoveRange(ratings);
            Assert.IsNull(repository.Get("1"));
            Assert.AreEqual(repository.Get("33").Id, "33");
        }

        public void AddMultipleRatingsToContext(Repository<Rating> repository)
        {
            var ratings = GetTestRatings();
            repository.AddRange(ratings);
        }
        
        public List<Rating> GetTestRatings()
        {
            List<Rating> ratings = new List<Rating>
            {
                new Rating
                {
                    Id = "1",
                    RatingValue = 3,
                    UserId = "1"
                },
                new Rating
                {
                    Id = "2",
                    RatingValue = 5,
                    UserId = "77"
                },
                new Rating
                {
                    Id = "3",
                    RatingValue = 1,
                    UserId = "100"
                }
            };
            return ratings;
        }
    }
}
