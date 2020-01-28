using RestSharp;
using restSharp_Try.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.GameParameteres
{
    public class NewUser
    {
        public int GameId { get; set; }
        public string GameCode { get; set; }
        private RestClient client;
        private string newUserCookie;


        public NewUser(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.newUserCookie = cookie;
        }

        public void GetInRoom()
        {
            string adress = "/rooms/play/" + GameCode;

            var request = new RestRequest(adress, Method.GET);

            request.AddHeader("Cookie", newUserCookie);

            IRestResponse response = client.Execute(request);
        }

        public GameInfoHelper CreateStory(string storyName)
        {
            var body = $"gameId={GameId}&" +
                $"name={storyName}";

            var request = new RestRequest("/api/stories/create/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", newUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(newUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper StartGame()    //this is also used for Next Story function as it has the same URL
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/next/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", newUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(newUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper Vote()   //votes are sent with this method; estimates are sent by FinishVoting() method
        {
            var body = $"gameId={GameId}&" +
                $"vote=2";

            var request = new RestRequest("/api/stories/vote/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", newUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(newUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper SkipStory()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/skip/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", newUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(newUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper ResetTimer()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/resetTimer", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", newUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(newUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper RevealCards()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/reveal/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", newUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(newUserCookie, GameId, client, GameCode);
        }
    }
}
