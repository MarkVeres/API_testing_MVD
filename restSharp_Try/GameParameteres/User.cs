using RestSharp;
using restSharp_Try.GameParameteres;

namespace restSharp_Try.Steps
{
    public class User
    {
        public User[] players { get; set; }    //this gives the list of players
        public string name { get; set; }       //this is for getting the name of the user
        public bool voted { get; set; }        //this is for seeing if the user has voted or not
        public bool gameStarted { get; set; }
        public bool closed { get; set; }      //this is for Finish voting
        public int? vote { get; set; }       //this is for the value of the vote
        public int id { get; set; }    //this is the player's ID
        public int inGameRole { get; set; }

        public string cookie;
        public int GameId;
        private RestClient client;

        public User(int gameId, RestClient client, string cookie, int id)
        {
            this.id = id;
            this.cookie = cookie;
            this.GameId = gameId;
            this.client = client;
        }

        public void ChangeRoleToObserver()
        {
            var body = $"gameId={GameId}&" +
                $"userId={id}&" +
                $"role=1";

            var request = new RestRequest("/api/games/updaterole", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            var response = client.Execute(request);
        }

        public User GetUserInfo()
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
    }
}
