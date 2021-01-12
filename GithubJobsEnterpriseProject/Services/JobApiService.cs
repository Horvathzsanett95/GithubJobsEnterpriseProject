using GithubJobsEnterpriseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GithubJobsEnterpriseProject.Controllers
{
    public class JobApiService : IJobApiService
    {
        IAppsettingsController _controller;
        public JobApiService(IAppsettingsController controller)
        {
            _controller = controller;
        }

        private string _urlParameters;

        public IEnumerable<GithubJob> GetGithubJobsFromUrl()
        {
            string url = _controller.GetLink().url;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(_urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<GithubJob>>().Result;
                return dataObjects;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }
            client.Dispose();
            return null;


        }

        public IEnumerable<GithubJob> GetGithubJobsByParameters(string descriptionParameter, string locationParameter)
        {
            string url = _controller.GetLink().plainUrl;
            _urlParameters = "positions.json?description=" + descriptionParameter + "&location=" + locationParameter;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(_urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<GithubJob>>().Result;
                return dataObjects;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }
            client.Dispose();
            return null;

        }
    }
}
