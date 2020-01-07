using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class StoryEdit
    {
        public StoryEdit[] Stories { get; set; }
        public int GameId { get; set; }
        private RestClient client;
        private string cookie;
        public string id { get; set; }   //this is the story Id

        public StoryEdit(int gameId, RestClient client, string cookie, string storyId)
        {
            this.GameId = gameId;
            this.client = client;
            this.cookie = cookie;
            this.id = storyId;
        }

        public void StoryDetails()
        {
            var body = $"storyId = {id}&" +
                $"gameId={GameId}";

            var request = new RestRequest("/stories/details/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public Story StoriesUpdate(string title)
        {
            var body = $"storyId = {id}&" +
                $"title={title}&" +
                $"estimate=";

            var request = new RestRequest("/stories/update/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Story>(content);

            return deserializeObject;
        }
    }
}
