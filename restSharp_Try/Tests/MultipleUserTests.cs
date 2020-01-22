using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try.Tests
{
    public class MultipleUserTests
    {
        [Fact]
        public void CanNewUserConnectToGame()  //not working yet; needs better methods
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");

            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();

            //assert
            var info = game.Vote();
            Assert.Equal("Jack", info.GetPlayersAndStateInfo().players[1].name);

        }
    }
}
