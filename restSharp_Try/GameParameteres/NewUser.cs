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
        private string secondCookie;


        public NewUser(int gameId, string gameCode, RestClient client, string cookie)
        {
            this.GameId = gameId;
            this.GameCode = gameCode;
            this.client = client;
            this.secondCookie = cookie;
        }

        public GameInfoHelper NewUserResolveGameRoom()
        {
            var body = $"gameCode={GameCode}";
            var request = new RestRequest("/api/games/resolveGameCode", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondCookie, GameId, client, GameCode);
        }

        public GameInfoHelper NewUserGetRole()
        {
            var body = $"gameId={GameId}";
            var request = new RestRequest("/api/games/getInGameRole", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondCookie, GameId, client, GameCode);
        }

        public GameInfoHelper GetPlayInfo()
        {
            var body = $"gameId={GameId}";
            var request = new RestRequest("/api/play/getPlayInfo", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondCookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return new GameInfoHelper(secondCookie, GameId, client, GameCode);
        }

        public void GetInRoom()
        {
            var request = new RestRequest($"/rooms/play/{GameCode}", Method.GET);;
            
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", secondCookie);

            var response = client.Execute(request);
        }
    }
}
