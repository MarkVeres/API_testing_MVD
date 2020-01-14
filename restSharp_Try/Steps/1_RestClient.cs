using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace restSharp_Try
{
    public class PlanitPockerClient
    {
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client;
        public PlanitPockerClient()
        {
            client = new RestClient(baseUrl);
        }
        public Player QuickPlayLogin(string userName)
        {
            var body = $"name={userName}";
            var request = new RestRequest("/api/authentication/anonymous", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            return new Player(cookie, client);
        }
        
        public Player SignUpLogin(string email, string name, string password)  //doesn't work, bad request status
        {
            var body = $"email={email}&" +
                $"&name={name}&" +
                $"&password={password}";
            var request = new RestRequest("/api/authentication/register", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            
            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            return new Player(cookie, client);
        }

        public Player LoginLogin(string email, string password)
        {
            var body = $"email={email}" +
                $"&password={password}";
            var request = new RestRequest("/api/authentication/login", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            return new Player(cookie, client);
        }
    }
}
