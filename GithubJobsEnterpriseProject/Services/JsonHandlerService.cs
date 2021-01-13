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
        private string _path;
        private IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

        IConfiguration _iconfig;
        public JsonHandlerService(IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }

        public string GetFilename()
        {
            return _iconfig.GetValue<string>("UsersPath:Filename");
        }

        public List<User> DeconvertUsersJson()
        {

            _path = GetFilename();

            if (isoStore.FileExists(_path))
            {
                Console.WriteLine("The file already exists!");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_path, FileMode.Open, isoStore))
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
            return null;
        }

        public void ConvertUserToJson(User user)
        {

            _path = GetFilename();

            if (isoStore.FileExists(_path))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_path, FileMode.Append, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }
            }
            else if (!isoStore.FileExists(_path))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_path, FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }

            }
        }

    }
}
