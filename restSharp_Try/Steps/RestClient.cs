using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace restSharp_Try
{
    public class PlanitPockerClient
    {
        private const string baseUrl = "https://www.planitpoker.com/api";
        private readonly RestClient client;
        public PlanitPockerClient()
        {
            client = new RestClient(baseUrl);
        }
        public Player QuickPlayLogin(string userName)
        {
            var body = $"name={userName}";
            var request = new RestRequest("/authentication/anonymous", Method.POST);
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
