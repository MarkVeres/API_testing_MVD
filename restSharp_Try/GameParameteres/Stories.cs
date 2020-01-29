using RestSharp;
using restSharp_Try.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try
{    
    public class Stories  //this class is for story creation & editing; CurrentStory if for during-gameplay stories
    {
        public Stories[] stories { get; set; }
        public string title { get; set; }
        public int GameId { get; set; }
        private RestClient client;
        private string cookie;
        public int id { get; set; }   //this is the story Id
        public int? estimate { get; set; }
        public bool storiesCreated { get; set; }
        public int? storiesCount { get; set; }

        public Stories(int gameId, RestClient client, string cookie, int storyId)
        {
            this.GameId = gameId;
            this.client = client;
            this.cookie = cookie;
            this.id = storyId;
        }

        public void StoryDetails()
        {
            var body = $"storyId={id}&" +
                $"gameId={GameId}";

            var request = new RestRequest("/api/stories/details/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public void StoriesUpdate(string title)
        {
            var body = $"storyId={id}&" +
                $"title={title}&" +
                $"estimate=5";

            var request = new RestRequest("/api/stories/update/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public Stories StoryGet()
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

            return deserializeObject;
        }

        public void StoriesDelete()
        {
            var body = $"gameId={GameId}&" +
                $"storyId={id}";

            var request = new RestRequest("/api/stories/delete/", Method.POST);

            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        public Stories GetStoryState()
        {
            var body = $"gameId={GameId}&";

            var request = new RestRequest("/api/games/getStoryState/", Method.POST);

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
