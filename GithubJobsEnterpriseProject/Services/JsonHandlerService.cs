using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using GithubJobsEnterpriseProject.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GithubJobsEnterpriseProject.Services
{
    public class JsonHandlerService
    {
        private const string _JSONPATH = "users.json";
        private IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);


        public List<User> DeconvertUsersJson()
        {


            if (isoStore.FileExists(_JSONPATH))
            {
                Console.WriteLine("The file already exists!");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_JSONPATH, FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        List<User> users = new List<User>();

                        string jsonString;
                        jsonString = reader.ReadToEnd();

                        var splittedJson = jsonString.Split("}");

                        for (int i = 0; i < splittedJson.Length - 1; i++)
                        {
                            splittedJson[i] += '}';
                            User user = JsonConvert.DeserializeObject<User>(splittedJson[i]);
                            users.Add(user);
                        }


                        return users;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void Save(User user)
        {

            if (isoStore.FileExists(_JSONPATH))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_JSONPATH, FileMode.Append, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }
            }
            else if (!isoStore.FileExists(_JSONPATH))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_JSONPATH, FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }

            }
            else
            {
                throw new FileNotFoundException();
            }
        }

    }
}
