using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try.Tests
{
    public class MultipleUserTests
    {
        [Fact]
        public void CanNewUserConnectToGame()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            var sGame = game.NewUserQuickPlayLogin("Jenny");
            sGame.GetInRoom();
            var info = game.StartGame();
            Assert.Equal("Jack", info.GetPlayersAndStateInfo().players[1].name);
            Assert.Equal("Jenny", info.GetPlayersAndStateInfo().players[2].name);
        }
    }
}
