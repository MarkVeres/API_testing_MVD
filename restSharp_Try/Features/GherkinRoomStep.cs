using RestSharp;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace restSharp_Try.Features
{
    public class GherkinRoomStep
    {
        private readonly string cookie;
        private readonly RestClient client;

        public GherkinRoomStep(string cookie, RestClient client)
        {
            this.cookie = cookie;
            this.client = client;
        }

        [When(@"I Create a Game Room")]
        public GherkinGameStep WhenICreateAGameRoom()
        {
            var body = $"name=Test Room" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/api/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GherkinGameStep(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }
    }
}
