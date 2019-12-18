using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace restSharp_Try
{

    public class GameRoom
    {
        
    }
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
            // aici parsează response content și crează un obiect de game...​

            return new GameRoom();
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
