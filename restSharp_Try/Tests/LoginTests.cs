using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try.Tests
{
    public class LoginTests
    {
        //Doesn't work, bad request status
        //[Fact]
        //public void SignUpLoginGameRoom()
        //{
        //    var client = new PlanitPockerClient();
        //    var player = client.SignUpLogin("gg@mail.com", "John", "password123");
        //    var game = player.CreateRoom("Test Room");
        //    Assert.NotNull(game.gameCode);
        //    doesn't work, bad request status
        //}

        [Fact]
        public void LoginToGameRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.LoginLogin("ggg@gggmail.com", "password123");
            var game = player.CreateRoom("Test Room");
            Assert.NotNull(game.gameCode);
        }
    }
}
