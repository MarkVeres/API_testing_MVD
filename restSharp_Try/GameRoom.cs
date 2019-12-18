using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace restSharp_Try
{
    public class Stories
    {
        public Story[] stories { get; set; }
    }
    public class Story
    {
        public int id;
        public string title;
        public Story(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    }
    public class GameRoom
    {
        public int gameId { get; set; }
        public string gameCode { get; set; }
        private RestClient client;
        private string cookie;

        public GameRoom(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.gameId = gameId;
            this.gameCode = gameCode;
            this.client = client;
            this.cookie = cookie;
        }
        public void CreateStory(string storyName)
        {
            var body = $"gameId={this.gameId}&" +
                $"name={storyName}";
               
            var request = new RestRequest("/stories/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            //return new Story();
        }
        public Stories GetStoryDetails()
        {
            var body = $"gameId={this.gameId}&" + 
                $"page=1&" + 
                $"skip=0&" + 
                $"perPage=25&" + 
                $"status=0&";

            var request = new RestRequest("/stories/get/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Stories>(content);

            return deserializeObject;
        }
    }
    public class Player
    {
        public readonly string cookie;
        private readonly RestClient client;        

        public Player(string cookie, RestClient client)
        {
            this.cookie = cookie;
            this.client = client;
        }

        public GameRoom CreateRoom(string roomName)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/games/create/", Method.POST);            

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);            

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            // aici parsează response content și crează un obiect de game...​
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.gameId, deserializeObject.gameCode, client, cookie);
        }
    }

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
