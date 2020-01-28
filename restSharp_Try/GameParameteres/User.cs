using RestSharp;
using restSharp_Try.GameParameteres;

namespace restSharp_Try.Steps
{
    public class User
    {
        public User[] players { get; set; }    //this gives the list of players
        public string name { get; set; }       //this is for getting the name of the user
        public bool voted { get; set; }        //this is for seeing if the user has voted
        public bool gameStarted { get; set; }
        public bool closed { get; set; }       //this is for Finish voting
        public int? vote { get; set; }        //this is for the value of the vote
        public int id { get; set; }    //this is the player's ID
        public int? inGameRole { get; set; }   //apparently, "5" is the role of Observer and "6" is the role of Moderator
                                              //player role is "2"

        public string cookie;
        public int GameId;
        public int Id { get; set; }
        private RestClient client;

        public User(int gameId, RestClient client, string cookie, int id)
        {
            this.Id = id;
            this.cookie = cookie;
            this.GameId = gameId;
            this.client = client;
        }

        public void ChangeRoleToObserver()
        {
            var body = $"gameId={GameId}&" +
                $"userId={Id}&" +
                $"role=1";

            var request = new RestRequest("/api/games/updaterole", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
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
