using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

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
            //since there is only 1 user in this room, the moderatorConnected assert can be used
            //also, it seems that the API response for moderator role check is "6"
            Assert.True(info.moderatorConnected);
        }

        [Fact]
        public void ChangeinGameRole()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var info = game.StartGame();
            var user = info.GetUserId();  //this does not deserialize used id (id)
                                          //needs fixing
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
            var start = game.StartGame();
            var info = start.GetStartGameInfo();
            //Assert should be updated to current year/date, accordingly
            Assert.Contains("2020", info.votingStart);
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
            Assert.Equal("Second Story", info.GetCurrentStoryInfo().title);
        }
        [Fact]
        public void ClearVotes()
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
        public void ResetGameTimer()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            game.Vote();
            var info  = game.ResetTimer();
            Assert.Null(info.GetPlayersAndStateInfo().players[0].voteDuration);
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
            story.StoryDetails();
            story.StoriesUpdate("First Story Modified");
            var edit = story.StoryGet();
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
            var edit = story.StoryGet();
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
