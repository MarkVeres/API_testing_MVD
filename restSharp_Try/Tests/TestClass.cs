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
        public void CreateRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            //this assert acceses the getPlayinfo and get the Room title
            Assert.Equal("Test Room", game.GetRoomInfo().title);
        }

        [Fact]
        public void CreateStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            Assert.Equal("Test Story", game.GetStoryInfo().Stories[0].Title);
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
            Assert.Equal("Test Story", game.GetStoryInfo().Stories[0].Title);
            Assert.Equal("Test Story 2", game.GetStoryInfo().Stories[1].Title);
            Assert.Equal("Third and Final Test Story", game.GetStoryInfo().Stories[2].Title);
        }

        [Fact]
        public void StartGame()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.StartGame();
            var start = game.GetStartGameInfo();
            //Assert should be updated to current year/date, accordingly
            Assert.Contains("2019", start.votingStart);
        }

        [Fact]
        public void UserVoting()
        {
            //bad request at Vote method
            //something wrong with request order
            //need to do more requests to set the current story and check if players are stated
            //follow request chain

            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.StartGame();
            game.GetStory();
            //game.GetCurrentStory();
            //game.GetCurrentStoryState();
            game.Vote();
            Assert.Equal("John", game.GetVoteInfo().players[0].name);
            Assert.True(game.GetVoteInfo().players[0].voted);
        }
    }
}
