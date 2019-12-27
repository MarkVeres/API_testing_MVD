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
            var info = game.CreateStory("Test Story");
            Assert.Equal("Test Story", info.GetStoryInfo().Stories[0].title);
        }

        [Fact]
        public void CreateMultipleStories()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.CreateStory("Test Story 2");
            var info = game.CreateStory("Third and Final Test Story");

            //Asserts the title of the stories, from the "stories" array
            Assert.Equal("Test Story", info.GetStoryInfo().Stories[0].title);
            Assert.Equal("Test Story 2", info.GetStoryInfo().Stories[1].title);
            Assert.Equal("Third and Final Test Story", info.GetStoryInfo().Stories[2].title);
        }

        [Fact]
        public void StartGame()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var start = game.StartGame();
            var info = start.GetStartGameInfo();
            //Assert should be updated to current year/date, accordingly
            Assert.Contains("2019", info.votingStart);
        }

        [Fact]
        public void UserVoting()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.StartGame();
            var info = game.Vote();
            Assert.Equal("John", info.GetVoteInfo().players[0].name);
            Assert.True(info.GetVoteInfo().players[0].voted);
        }

        [Fact]
        public void FinishVoting()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            game.StartGame();
            game.Vote();
            var info = game.FinishVoting();
            Assert.True(info.GetPlayersAndStateInfo().closed);           
        }
        [Fact]
        public void NextStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.CreateStory("Second Story");
            game.StartGame();
            game.Vote();
            game.FinishVoting();
            var info  = game.StartGame();
            Assert.Equal("Second Story", info.GetCurrentStory().title);
        }

        [Fact]
        public void SkipStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.CreateStory("Second Story");
            game.StartGame();
            game.SkipStory();
            var info = game.StartGame();
            Assert.Equal("Second Story", info.GetCurrentStory().title);
        }

        [Fact]
        public void ResetGameTimer()
        {
            //doesn't work correctly, votingDuration stays 0 until you Finish  voting,
            //at which point, you can no longer reset the Timer
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            game.Vote();
            var info  = game.ResetTimer();
            Assert.True(info.GetCurrentStory().votingDuration == 0);
        }
    }
}
