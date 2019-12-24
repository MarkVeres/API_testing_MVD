using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try.Tests
{
    public class PostmanTests
    {
        [Fact]
        public void GetRoomName()
        {
            var client = new RestClient("https://www.planitpoker.com/api/play/getPlayInfo");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:71.0) Gecko/20100101 Firefox/71.0");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Language", "en-US,en;q=0.5");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Origin", "https://www.planitpoker.com");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Referer", "https://www.planitpoker.com/board/");
            request.AddHeader("Cookie", "__cfduid=dde2d1cba850501ba6554e2324d986d2a1575274830; _ga=GA1.2.1041236934.1575274829; .AspNet.TwoFactorRememberBrowser=5daLKnNruUfiF7ZVjumb-13w0xEq7pjEHAXU6WDJh9imp5HrNgTXDfTK9huQeoUKStAPk9smxo0BPOgEYx_HQkitwtAuhANnCzeCugktqln1GWXCQMD4a9pJUZHoFZYhtj48XU5cHun-a5jo79av3F_P5FXEp8fH2e6YNhaQfz8SGLakwrNcuQlIFfGOvMTZodNBgygDp2IYjYIoIKbp8r2M_veB2eFnpOUqGUx2ASmVyK8FCN2NUSMy_uXW4iL8toTKB0naEyLTqD81ttaIsi6gZbZBZCy7vgMSigm3sBJsMvT3dsbttbVPNwY6-75slZrKO9pLPjmJ0dF3lT6Dlw; uvts=0fc33b47-97cb-490a-5c36-63a62e5bdcd7; _gid=GA1.2.1372192732.1577102715; _gat=1; .AspNet.ApplicationCookie=fxcU1Z1oE_4GAIu02JS8UvQokYuBGCEdVF2tA5JNdrml8x-yIAmmDOp_J1dS7Wi6f0tu8LxOgg5wkBVKs7MdB02lIoGWzBEXeWOkEuBEtZ_S9rA8f-h3elmXqqj2OwyC_1EpGuea5XftGr0FXjsk-QvcDSDL8q-hH0Ti4ZSN9JZBQa7I5mYUJ9d38_TCoUT8UEucb5DF3UvVMs2MdgUh0SDy7R1gbxSJ2EMksLbNJY8-sjU3lByiL7EeXnbY1nAwJCdg1pW0d1Wm7Z584RyE-C31zXqsf2mx-rjnbXoYUNpM-uxSHdLoMDyPD4HJK6sgCKMmkKwGfeucyfcvnAOBqnJ6WD4LXUN9VyE4qO3B7AdtJsTQWrM4D7Tcr068rdD7ryv9MZnP-bbICobE0WjywLHZcYDCRSXXw9PcJfG7a3D3Md5haJFWVSTBQVfpzSka");
            request.AddHeader("TE", "Trailers");
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", "gameId=433670", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string status = response.StatusCode.ToString();
            Assert.Equal("OK", status);
        }

        [Fact]
        public void StartVote()
        {
            var client = new RestClient("https://www.planitpoker.com/api/stories/next/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:71.0) Gecko/20100101 Firefox/71.0");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Language", "en-US,en;q=0.5");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Origin", "https://www.planitpoker.com");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Referer", "https://www.planitpoker.com/board/");
            request.AddHeader("Cookie", "__cfduid=dde2d1cba850501ba6554e2324d986d2a1575274830; _ga=GA1.2.1041236934.1575274829; .AspNet.TwoFactorRememberBrowser=RUlyqgJUizy0mfwwkLyfbcbb8feKDCjTiVeEcv_t-Htfl-4RytiH60fN3yEYltE-GI8_EhBGirHEeofhseJyktYfwXOBhQHRJMV3gagjrH8F7rLOp8Nc3htbpcTQld8nb2uOPDC8sayS6JSkjZvtVz5keZJj8bznFuQu57EAne8wbtcqwDlGhv98LmxtRe8tjEEr19oUWGoQOiai2H2It_8-5Dok_VcRJAqm5rs0RzyIdvulIdx-ofdGEu7jlRsSPqQHZMw9M0VbitPqQ4ulaXje96jDV_Cj1dgLz6v285oF5HiKA74l0da8l923IYb2jYMkCrfYyX6x1RgcAsKk7Q; uvts=2fed2a5a-4c9f-464e-456d-831211306e97; _gid=GA1.2.1372192732.1577102715; _gat=1; .AspNet.ApplicationCookie=2SQQTQ3fSegjQUGHalqb6CAdc5Phrfooi83SBo-OzinpyLWQg5xpZv3EavP6v3MD0JOkRjIMhVhF10y5Z8BubtOLEITIXZCdRVEgVCSPTruu2_qq4896UWF_xBEw3iazCJ3m7AMx0ZLQ0FMn9GB7mHLkcjjExWERmqp3NbY-vMhoTcdG2QzJogkbOB1KGGC3PyVGaVU1sASnh4rSloB8Yepl5NQkhj9GYdLm4Ldq6KUuYiUjbPSy1lLtv8WcKaNzrJp-X7peB237zAzbKz-aP_MjQ0qOz9h7w4qs7NMi9QR619MbdK-Mv9cTaBD83f_0rmwwFPbgnTXc3C_C3ywOGs9nRpt3W3deLiLzEwu2e5gGPQCD0AKcDzEMe0HOondbjVDHPARSluab1k-BTgxHNrFv8NtGXmiqAWRpw8umYXQwpgfrpb8Kx5LxB9S3nmq6");
            request.AddHeader("TE", "Trailers");
            request.AddParameter("application/x-www-form-urlencoded", "gameId=433438", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string status = response.StatusCode.ToString();
            Assert.Equal("OK", status);
        }
        [Fact]
        public void GetUserVoted()
        {
            var client = new RestClient("https://www.planitpoker.com/api/games/gameStoryVoteEvent");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:71.0) Gecko/20100101 Firefox/71.0");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Language", "en-US,en;q=0.5");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Origin", "https://www.planitpoker.com");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Referer", "https://www.planitpoker.com/board/");
            request.AddHeader("Cookie", "__cfduid=dde2d1cba850501ba6554e2324d986d2a1575274830; _ga=GA1.2.1041236934.1575274829; .AspNet.TwoFactorRememberBrowser=5daLKnNruUfiF7ZVjumb-13w0xEq7pjEHAXU6WDJh9imp5HrNgTXDfTK9huQeoUKStAPk9smxo0BPOgEYx_HQkitwtAuhANnCzeCugktqln1GWXCQMD4a9pJUZHoFZYhtj48XU5cHun-a5jo79av3F_P5FXEp8fH2e6YNhaQfz8SGLakwrNcuQlIFfGOvMTZodNBgygDp2IYjYIoIKbp8r2M_veB2eFnpOUqGUx2ASmVyK8FCN2NUSMy_uXW4iL8toTKB0naEyLTqD81ttaIsi6gZbZBZCy7vgMSigm3sBJsMvT3dsbttbVPNwY6-75slZrKO9pLPjmJ0dF3lT6Dlw; uvts=0fc33b47-97cb-490a-5c36-63a62e5bdcd7; _gid=GA1.2.1372192732.1577102715; .AspNet.ApplicationCookie=fxcU1Z1oE_4GAIu02JS8UvQokYuBGCEdVF2tA5JNdrml8x-yIAmmDOp_J1dS7Wi6f0tu8LxOgg5wkBVKs7MdB02lIoGWzBEXeWOkEuBEtZ_S9rA8f-h3elmXqqj2OwyC_1EpGuea5XftGr0FXjsk-QvcDSDL8q-hH0Ti4ZSN9JZBQa7I5mYUJ9d38_TCoUT8UEucb5DF3UvVMs2MdgUh0SDy7R1gbxSJ2EMksLbNJY8-sjU3lByiL7EeXnbY1nAwJCdg1pW0d1Wm7Z584RyE-C31zXqsf2mx-rjnbXoYUNpM-uxSHdLoMDyPD4HJK6sgCKMmkKwGfeucyfcvnAOBqnJ6WD4LXUN9VyE4qO3B7AdtJsTQWrM4D7Tcr068rdD7ryv9MZnP-bbICobE0WjywLHZcYDCRSXXw9PcJfG7a3D3Md5haJFWVSTBQVfpzSka");
            request.AddHeader("TE", "Trailers");
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", "gameId=433670", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string status = response.StatusCode.ToString();
            Assert.Equal("OK", status);
        }
    }
}
