using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using System.Threading;

namespace restSharp_Try
{
    public class GameTests
    {        
        [Fact]
        public void CreateRoom()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            Assert.Equal("Test Room", game.GetRoomInfo().title);
        }

        [Fact]
        public void CreateStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            var info = game.CreateStory("Test Story");
            Assert.Equal("Test Story", info.GetStoryInfo().stories[0].title);
        }

        [Fact]
        public void UserThatCreatedGameShouldBeModerator()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var info = game.GetRoomInfo();
            Assert.True(info.moderatorConnected);
        }

        //user Id is needed to change user roles; however it cannot be deserialized
        //deserialization does not work in the players[...] array, only on elements outside this array
        [Fact]
        public void ChangeinGameRole()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var info = game.StartGame();
            var user = info.GetUserId();
            user.ChangeRoleToObserver();
            var sert = user.GetUserInfo();
            Assert.Equal(5, sert.players[0].inGameRole);
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
            Assert.Equal("Third and Final Test Story", info.GetStoryInfo().stories[2].title);
        }

        [Fact]
        public void StartGame()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var info = game.StartGame();
            Assert.True(info.GetPlayersAndStateInfo().gameStarted);
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
            var info = game.StartGame();
            Assert.Equal("Second Story", info.GetCurrentStoryInfo().title);
        }

        [Fact]
        public void ClearVotesBeforeFinishVoting()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            game.Vote();
            var info = game.ClearVotes();
            Assert.False(info.GetPlayersAndStateInfo().players[0].voted);
        }

        [Fact]
        public void ClearVotesAfterFinishVoting()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            game.Vote();
            game.FinishVoting();
            var info = game.ClearVotes();
            Assert.False(info.GetPlayersAndStateInfo().players[0].voted);
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
            Assert.Equal("Second Story", info.GetCurrentStoryInfo().title);
        }

        [Fact]
        public void ResetGameTimer()    //TIMER TESTS ARE NOT POSSIBLE BY API
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            var info = game.StartGame();
            var first = info.GetCurrentStoryInfo();
            var initialTimer = first.GetVotingStart();
            game.ResetTimer();
            var second = info.GetCurrentStoryInfo();
            var resetTimer = second.GetVotingStart();
            //since voting duration can change based on how fast the test runs, votingDuration CANNOT be used
            //after reseting the timer, votingStart receives new time and code values (votingStart string will be different)
            //thus the votingStart parameter is stored in 2 variables
            //if the timer is actually reset, those 2 variables will be different
            Assert.True(initialTimer != resetTimer);
        }

        [Fact]
        public void RevealCards()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            var info = game.RevealCards();
            //if the user has not voted and the Moderator has revealed the cards,
            //that specific user will have his vote value set to -1
            Assert.Equal(-1, info.GetVoteInfo().players[0].vote);
        }

        [Fact]
        public void ChangeStoryName()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            var info = game.CreateStory("First Story");
            var story = info.GetStoryEditInfo();
            story.StoriesUpdate("First Story Modified");
            var edit = story.GetStoryChangeInformation();
            Assert.Equal("First Story Modified", edit.stories[0].title);
        }

        [Fact]
        public void AddNewStoryAfterVotingFinishes()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.CreateStory("Second Story");
            game.StartGame();
            game.Vote();
            game.FinishVoting();
            var info = game.CreateStory("Third Story After Voting");
            //voting on the First Story is done, so it is not longer in the initial list
            //therefore the "Second Story" has the index of "0"
            //and the Latest added story is next in line, thus index "1"
            Assert.Equal("Third Story After Voting", info.GetStoryInfo().stories[1].title);
        }

        [Fact]
        public void DeleteStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            var info = game.CreateStory("Test Story");
            var story = info.GetStoryEditInfo();
            story.StoriesDelete();
            var sert = story.GetStoryState();
            //since only 1 story was created, if that story is deleted, there are no "created" stories anymore
            Assert.False(sert.storiesCreated);
        }

        [Fact]
        public void ChangeEstimate()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            game.Vote();
            var info = game.FinishVoting();
            var story = info.GetStoryEstimateEditInfo();
            story.StoriesUpdate("First Story");
            var edit = story.GetStoryChangeInformation();
            Assert.Equal(5, edit.stories[0].estimate);
        }

        [Fact]
        public void ExportGameReport()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            game.Vote();
            game.FinishVoting();
            var info = game.GetGameReport();
            Assert.Contains("John", info.GetExportInfo());
            Assert.Contains("First Story", info.GetExportInfo());
        }
    }
}
