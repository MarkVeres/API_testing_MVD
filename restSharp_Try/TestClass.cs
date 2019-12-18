using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace restSharp_Try
{
    public class TestClass
    {
        PlanitPockerClient client;

        public TestClass()
        {
            this.client = new PlanitPockerClient();
        }

        [Fact]
        public void GameRoomTest()
        {
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            Assert.NotNull(game.gameCode);
        }

        [Fact]
        public void GameRoomStory()
        {
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            string cookie = player.cookie;
            game.CreateStory("Test Story");
            game.CreateStory("test story ggg");
            var story = game.GetStoryDetails().stories[1];
            Assert.Equal("test story ggg", story.title);
            Assert.Equal("Test Story", game.GetStoryDetails().stories[0].title);
        }

        //copy gameRoomStory
        //assert each Story title
    }
}
