using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace restSharp_Try
{
    public class TestClass
    {
        [Fact]
        public void GameRoomTest()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            Assert.NotNull(game.gameCode);
        }

        [Fact]
        public void GameRoomStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            string cookie = player.cookie;
            game.CreateStory("Test Story");
            game.CreateStory("test story ggg");
            var story = game.GetStoryDetails().stories[1];
            Assert.Equal("test story ggg", story.title);
            Assert.Equal("Test Story", game.GetStoryDetails().stories[0].title);
        }

        [Fact]
        public void MultipleStoriesTitles()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            string cookie = player.cookie;
            game.CreateStory("Test Story");
            game.CreateStory("Test Story 2");
            game.CreateStory("Third and Final Test Story");
            Assert.Equal("Test Story", game.GetStoryDetails().stories[0].title);
            Assert.Equal("Test Story 2", game.GetStoryDetails().stories[1].title);
            Assert.Equal("Third and Final Test Story", game.GetStoryDetails().stories[2].title);
        }
    }
}
