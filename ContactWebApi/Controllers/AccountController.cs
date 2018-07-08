using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ContactWebApi.Controllers
{
    public class AccountController : ApiController
    {
        public void GetToken()
        {
            string baseAddress = "http://localhost:4312";
            Token token = new Token();
            using (var client = new HttpClient())
            {
                var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", "jignesh"},
                   {"password", "user123456"},
               };
                var tokenResponse = client.PostAsync(baseAddress + "/oauth/token", new FormUrlEncodedContent(form)).Result;
                //var token = tokenResponse.Content.ReadAsStringAsync().Result;
                token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                if (string.IsNullOrEmpty(token.Error))
                {
                    Console.WriteLine("Token issued is: {0}", token.AccessToken);
                    Console.WriteLine("Token Type: {0}", token.TokenType);
                }
                else
                {
                    Console.WriteLine("Error : {0}", token.Error);
                }
            }

            // Next Request 
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseAddress);
                //httpClient1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
                httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token.AccessToken));
                HttpResponseMessage response = httpClient.GetAsync("api/TestMethod").Result;
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Success");
                }
                string message = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
