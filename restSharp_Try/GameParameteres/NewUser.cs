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
        private string secondUserCookie;

        public NewUser(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.secondUserCookie = cookie;
        }

        public void GetInGameRoom()
        {
            string adress = "/rooms/play/" + GameCode;

            var request = new RestRequest(adress, Method.GET);

            request.AddHeader("Cookie", secondUserCookie);

            IRestResponse response = client.Execute(request);
        }

        public GameInfoHelper CreateStory(string storyName)
        {
            var body = $"gameId={GameId}&" +
                $"name={storyName}";

            var request = new RestRequest("/api/stories/create/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper StartGame()   //this is also used for Next Story function as it uses the same request path
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/next/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper Vote()   //votes are sent with this method; estimates are sent by FinishVoting() method
        {
            var body = $"gameId={GameId}&" +
                $"vote=2";

            var request = new RestRequest("/api/stories/vote/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper SkipStory()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/skip/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper ResetTimer()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/resetTimer", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper RevealCards()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/reveal/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper ClearVotes()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/resetCurrentStory/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public GameInfoHelper FinishVoting()    //estimates are send with this method!!!
        {
            var body = $"gameId={GameId}&" +
                $"estimate=3";

            var request = new RestRequest("/api/stories/finish/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondUserCookie, GameId, client, GameCode);
        }

        public Stories GetStoryEditInfo()  //used for changing story name
        {
            var body = $"gameId={GameId}&" +
                $"page=1&" +
                $"skip=0&" +
                $"perPage=25&" +
                $"status=0&";

            var request = new RestRequest("/api/stories/get/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondUserCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Stories>(content);

            return new Stories(GameId, client, secondUserCookie, deserializeObject.stories[0].id);
        }
    }
}
