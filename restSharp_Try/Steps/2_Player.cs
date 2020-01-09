using RestSharp;
using restSharp_Try.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try
{
    public class Player
    {
        private readonly string cookie;
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

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }

        public GameRoom CreateRoomHaveStories(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories={tf}" +
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

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }

        public GameRoom CreateRoomSkipConfirmation(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip={tf}" +
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

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }

        public GameRoom CreateRoomObserverSeeingVotes(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers={tf}" +
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

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }

        public GameRoom CreateRoomAutoVoteReveal(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal={tf}" +
                $"&changeVote=false" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }

        public GameRoom CreateRoomAllowChangeVote(string roomName, bool tf)
        {
            var body = $"name={roomName}" +
                $"&cardSetType=1" +
                $"&haveStories=true" +
                $"&confirmSkip=true" +
                $"&showVotingToObservers=true" +
                $"&autoReveal=true" +
                $"&changeVote={tf}" +
                $"&countdownTimer=false" +
                $"&countdownTimerValue=30";
            var request = new RestRequest("/games/create/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }

        public GameRoom UseCountDownTimer(string roomName, bool tf, int duration)
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

            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GameRoom>(content);

            return new GameRoom(deserializeObject.GameId, deserializeObject.GameCode, client, cookie);
        }        
    }
}
