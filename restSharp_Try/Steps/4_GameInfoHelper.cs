using RestSharp;
using restSharp_Try.GameParameteres;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace restSharp_Try.Steps
{
    public class GameInfoHelper
    {
        public string cookie;
        public int GameId;
        public string GameCode { get; set; }
        private RestClient client;
        public GameInfoHelper(string cookie, int gameId, RestClient client, string gameCode)
        {
            this.cookie = cookie;
            this.GameId = gameId;
            this.client = client;
            this.GameCode = gameCode;
        }

        public User GetRoomInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }

        public CurrentStory GetCurrentStoryInfo()    //used for the NextStory Test Assert
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getCurrentStory/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentStory>(content);

            return deserializeObject;
        }
        public Stories GetStoryInfo()
        {
            var body = $"gameId={GameId}&" +
                $"page=1&" +
                $"skip=0&" +
                $"perPage=25&" +
                $"status=0&";

            var request = new RestRequest("/api/stories/get/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Stories>(content);

            return deserializeObject;
        }

        public Stories GetStoryEditInfo()
        {
            var body = $"gameId={GameId}&" +
                $"page=1&" +
                $"skip=0&" +
                $"perPage=25&" +
                $"status=0&";

            var request = new RestRequest("/api/stories/get/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Stories>(content);

            return new Stories(GameId, client, cookie, deserializeObject.stories[0].id);
        }

        public Stories GetStoryEstimateEditInfo()
        {
            var body = $"gameId={GameId}&" +
                $"page=1&" +
                $"skip=0&" +
                $"perPage=25&" +
                $"sortingKey=votingStart&" +
                $"reverse=true";

            var request = new RestRequest("/api/stories/get/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Stories>(content);

            return new Stories(GameId, client, cookie, deserializeObject.stories[0].id);
        }

        public User GetStartGameInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/stories/next/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }

        public User GetVoteInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/gameStoryVoteEvent", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }

        public User GetPlayersAndStateInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getPlayersAndState/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return deserializeObject;
        }

        public List<ListRoom> GetGamesListInfo()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getList/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ListRoom>>(content);

            return deserializeObject;
        }

        public string GetExportInfo()
        {
            string adress = "https://www.planitpoker.com/board/exportstories//" + Convert.ToString(GameId);
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Cookie", cookie);
            string information = webClient.DownloadString(adress);

            return information;
        }

        public User GetUserId()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

            return new User(GameId, client, cookie, deserializeObject.players[0].id);
            //does not deserialize anything within the players[...] array
        }
    }
}
