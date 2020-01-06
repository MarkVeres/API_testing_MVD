using RestSharp;
using restSharp_Try.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace restSharp_Try
{   
    public class GameRoom
    {
        public int GameId { get; set; }
        public string GameCode { get; set; }
        private RestClient client;
        private string cookie;

        public GameRoom(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }
        public Room GetRoomInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Room>(content);

            return deserializeObject;
        }
        public GetInfo CreateStory(string storyName)
        {
            var body = $"gameId={GameId}&" +
                $"name={storyName}";

            var request = new RestRequest("/stories/create/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }

        public GetInfo StartGame()    //this is also used for Next Story function as it has the same URL
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/stories/next/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }
        
        public GetInfo SkipStory()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/stories/skip/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }

        public GetInfo Vote()
        {
            var body = $"gameId={GameId}&" +
                $"vote=2";

            var request = new RestRequest("/stories/vote/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }

        public GetInfo FinishVoting()
        {
            var body = $"gameId={GameId}&" +
                $"estimate=3";

            var request = new RestRequest("/stories/finish/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }

        public GetInfo ResetTimer()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/games/resetTimer/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }

        public GetInfo ClearVotes()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/games/resetCurrentStory/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }

        public GetInfo RevealCards()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/stories/reveal/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GetInfo(cookie, GameId, client);
        }
    }
}
