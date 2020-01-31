using RestSharp;
using restSharp_Try.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using restSharp_Try.GameParameteres;
using Xunit;
using TechTalk.SpecFlow;

namespace restSharp_Try.Features
{
    public class GherkinGameStep
    {
        public int GameId { get; set; }
        public string GameCode { get; set; }
        private RestClient client;
        private string cookie;


        public GherkinGameStep(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }

        [When(@"I request Room Information")]
        public string GetRoomTitle()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Room>(content);

            return deserializeObject.title;
        }

        [Then(@"The Game Room name should be the one I Created the Room with")]
        public void ThenTheGameCodeShouldExist()
        {
            Assert.Equal("Test Room", GetRoomTitle());
        }
    }
}
