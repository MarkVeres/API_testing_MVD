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
            var body = $"gameId={gameId}&" +
                $"name={storyName}";
               
            var request = new RestRequest("/stories/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            //return new Story();
        }
        public GameRoom StartGame()
        {
            var body = $"gameId={gameId}&";

            var request = new RestRequest("/games/getPlayersAndState", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

           return new GameRoom(gameId, gameCode, client, cookie);
        }

        public GameRoom Vote()
        {
            var body = $"gameId={gameId}&" +
                $"vote=2";

            var request = new RestRequest("/stories/vote/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameRoom(gameId, gameCode, client, cookie);
        }

        public User GetVoteDetails()
        {
            var body = $"gameId={gameId}&";

            var request = new RestRequest("/games/gameStoryVoteEvent", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }

        public Stories GetStoryDetails()
        {
            var body = $"gameId={gameId}&" + 
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
}
