using RestSharp;
using restSharp_Try.Features;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace restSharp_Try
{
    [Binding]
    public class GherkinLoginSteps
    {
        private const string baseUrl = "https://www.planitpoker.com";
        private readonly RestClient client;

        public GherkinLoginSteps()
        {
            client = new RestClient(baseUrl);
        }

        [Given(@"I have logged in via QuickPlay")]
        public GherkinRoomStep GivenIHaveLoggedInViaQuickPlay()
        {
            var body = $"name=John";
            var request = new RestRequest("/api/authentication/anonymous", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            var cookie = response.Headers
                .First(h => h.Name == "Set-Cookie")
                .Value
                .ToString();

            return new GherkinRoomStep(cookie, client);
        }        
    }
}
