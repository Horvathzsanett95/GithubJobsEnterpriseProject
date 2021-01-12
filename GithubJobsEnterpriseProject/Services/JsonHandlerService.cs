using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using GithubJobsEnterpriseProject.Models;
using Newtonsoft.Json;

namespace GithubJobsEnterpriseProject.Services
{
    public class JsonHandlerService
    {

        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

        public List<User> DeconvertUsersJson()
        {
            if (isoStore.FileExists("users.json"))
            {
                Console.WriteLine("The file already exists!");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.Open, isoStore))
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
            if (isoStore.FileExists("users.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.Append, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    }
                }
            }
            else if (!isoStore.FileExists("users.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("users.json", FileMode.CreateNew, isoStore))
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
