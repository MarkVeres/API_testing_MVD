using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try.Tests
{
    public class LoginTests
    {
        [Fact]
        public void QuickPlayLoginGameRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            var info = game.GetRoomInfo();
            Assert.Equal("Test Room", info.title);
        }

        [Fact]
        public void LoginToGameRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.LoginLogin("ggg@gggmail.com", "password123");
            var game = player.CreateRoom("Test Room");
            var info = game.GetRoomInfo();
            Assert.Equal("Test Room", info.title);
        }

        [Fact]
        public void SignUpLoginGameRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.SignUpLogin("gg@mail.com", "John", "password123");
            var game = player.CreateRoom("Test Room");
            var info = game.GetRoomInfo();
            Assert.Equal("Test Room", info.title);
        }
    }
}
