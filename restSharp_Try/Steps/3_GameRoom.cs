using RestSharp;
using restSharp_Try.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

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
        public GameInfoHelper CreateStory(string storyName)
        {
            var body = $"gameId={GameId}&" +
                $"name={storyName}";

            var request = new RestRequest("/stories/create/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper StartGame()    //this is also used for Next Story function as it has the same URL
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/stories/next/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }
        
        public GameInfoHelper SkipStory()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/stories/skip/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper Vote()   //votes are sent with this method; estimates are sent by FinishVoting() method
        {
            var body = $"gameId={GameId}&" +
                $"vote=2";

            var request = new RestRequest("/stories/vote/", Method.POST);
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper FinishVoting()    //estimates are send with this method!!!
        {
            var body = $"gameId={GameId}&" +
                $"estimate=3";

            var request = new RestRequest("/stories/finish/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper ResetTimer()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/games/resetCurrentStory/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper ClearVotes()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/games/resetCurrentStory/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper RevealCards()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/stories/reveal/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper ResetGameRoom()
        {
            var body = $"gameId={GameId}";
            var request = new RestRequest("/games/reset/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        //this can be used to edit any setting after the room has been created
        //just change parameters
        public GameInfoHelper EditCreatedGameRoom(string roomName, bool tf, int duration)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote=false" +
                $"&countdownTimer={tf}" +
                $"&countdownTimerValue={duration}";
            var request = new RestRequest("/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }

        public GameInfoHelper DeleteGameRoom()
        {
            var body = $"gameId={GameId}";
            var request = new RestRequest("/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(cookie, GameId, client, GameCode);
        }
    }
}
