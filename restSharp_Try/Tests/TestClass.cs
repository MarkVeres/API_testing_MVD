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
        public void QuickPlayLoginGameRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            Assert.NotNull(game.gameCode);
        }

        [Fact]
        public void CreateStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            Assert.Equal("Test Story", game.GetStoryDetails().stories[0].title);
        }

        [Fact]
        public void CreateMultipleStories()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.CreateStory("Test Story 2");
            game.CreateStory("Third and Final Test Story");
            //Asserts the title of the stories, from the "stories" array
            Assert.Equal("Test Story", game.GetStoryDetails().stories[0].title);
            Assert.Equal("Test Story 2", game.GetStoryDetails().stories[1].title);
            Assert.Equal("Third and Final Test Story", game.GetStoryDetails().stories[2].title);
        }

        [Fact]
        public void UserVoting()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.StartGame();
            game.Vote();
            Assert.Equal("John", game.GetVoteDetails().name);
            Assert.True(game.GetVoteDetails().voted);
        }
    }
}
