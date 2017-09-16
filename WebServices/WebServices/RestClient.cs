using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebServices.Model;

namespace WebServices
{
    public class RestClient
    {
        string authHeaderValue = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhaXRyaWNoQG1kIiwiYXV0aCI6IlJPTEVfQURNSU4iLCJjb21wYW55SWQiOjg0MDIsImV4cCI6MTUwNDE3OTUxMn0.k55k9ANe40mGDl5wJ1xxv5D1es34GgrxV3tZf7lZ8cqXVhKXbXhAZ2nWNhkPQAHsCz43tbVUzV2RZLVeOjI3zg";
        HttpClient client = new HttpClient();
        public async Task<T> Get<T>(string url)
        {
            try
            {

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authHeaderValue);
                var response = await client.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                }
            }
            catch
            {

            }
            return default(T);
        }
        public async Task<Authorization> Post<T>()
        {
            var jsonstring = "";


                var login = new login();
                login.username = "aitrich@md";
                login.password = "md123";
                login.rememberMe = false;
                var json = JsonConvert.SerializeObject(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://192.168.0.73/api/authenticate", content);


            if (response != null)
                {
                    jsonstring = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Authorization>(jsonstring);
            }
            else {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Authorization>(jsonstring); }

                 }
           // return default(T);
        }
    }
