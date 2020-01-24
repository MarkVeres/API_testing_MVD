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

        public void GetInRoom()
        {
            string adress = "/rooms/play/" + GameCode;

            var request = new RestRequest(adress, Method.GET);

            request.AddHeader("Cookie", secondCookie);

            IRestResponse response = client.Execute(request);
        }
    }
}
