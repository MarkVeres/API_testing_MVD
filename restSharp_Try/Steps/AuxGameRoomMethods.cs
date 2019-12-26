using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class AuxGameRoomMethods
    {
        //public GameRoom GetStory()
        //{
        //    var body = $"gameId={GameId}&" +
        //        $"page=1&" +
        //        $"skip=0&" +
        //        $"perPage=25&" +
        //        $"status=0";

        //    var request = new RestRequest("/stories/get/", Method.POST);

        //    request.AddHeader("Content-Length", body.Length.ToString());
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddHeader("Cookie", cookie);

        //    request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

        //    var response = client.Execute(request);

        //    return new GameRoom(GameId, GameCode, client, cookie);
        //}

        //public GameRoom GetCurrentStory()
        //{
        //    var body = $"gameId={GameId}&";

        //    var request = new RestRequest("/games/getCurrentStory/", Method.POST);

        //    request.AddHeader("Content-Length", body.Length.ToString());
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddHeader("Cookie", cookie);

        //    request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

        //    var response = client.Execute(request);

        //    return new GameRoom(GameId, GameCode, client, cookie);
        //}
        //public GameRoom GetCurrentStoryState()
        //{
        //    var body = $"gameId={GameId}&";

        //    var request = new RestRequest("/games/getCurrentStoryState/", Method.POST);

        //    request.AddHeader("Content-Length", body.Length.ToString());
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddHeader("Cookie", cookie);

        //    request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

        //    var response = client.Execute(request);

        //    return new GameRoom(GameId, GameCode, client, cookie);
        //}

        //public GameRoom GetInfo()
        //{
        //    var body = $"gameId={GameId}&";

        //    var request = new RestRequest("/games/getinfo", Method.POST);

        //    request.AddHeader("Content-Length", body.Length.ToString());
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddHeader("Cookie", cookie);

        //    request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

        //    var response = client.Execute(request);

        //    return new GameRoom(GameId, GameCode, client, cookie);
        //}
    }
}
