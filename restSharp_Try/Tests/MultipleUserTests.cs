using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading;

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

        [Fact]
        public void CanNewUserCreateAStory()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            var info = uGame.CreateStory("New User Test Story");
            //second user cannot create stories; 
            //thus even if he calls the "CreateStory" API, the number of stories is the number of stories created by the moderator
            Assert.Equal(1, info.GetStoryInfo().storiesCount);
        }

        [Fact]
        public void CanNewUserStartTheGame()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            var info = uGame.StartGame();
            Assert.False(info.GetRoomInfo().gameStarted);  
        }

        [Fact]
        public void CanNewUserVote()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("Test Story");
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            game.StartGame();
            var info = uGame.Vote();
            //test working as it should
            //extra assert to make sure that the vote is not registered for User John
            //Assert.False(info.GetVoteInfo().players[0].voted);
            Assert.True(info.GetVoteInfo().players[1].voted);
        }

        [Fact]
        public void CanNewUserSkipStories()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.CreateStory("Second Story");
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            game.StartGame();
            uGame.SkipStory();
            var info = game.StartGame();
            //the Skip Story action is performed by the second user, so it does not pass, even after
            //theoretically proceeding to the next story by "Startgame()" method
            //"First Story" remains the current story
            Assert.Equal("First Story", info.GetCurrentStoryInfo().title);
        }

        [Fact]
        public void CanNewUserResetTimer()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            var info = game.StartGame();
            var first = info.GetCurrentStoryInfo();
            var initialTimer = first.GetVotingStart();
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            uGame.ResetTimer();
            var second = info.GetCurrentStoryInfo();
            var resetTimer = second.GetVotingStart();
            //see ResetGameTimerTest in GameTests.cs
            //since the timer cannot be reset by the non-Moderator-user, the 2 variables are the same
            Assert.True(initialTimer == resetTimer);
        }

        [Fact]
        public void CanNewUserRevealCards()  //BUG FOUND !!!
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoom("Test Room");
            game.CreateStory("First Story");
            game.StartGame();
            var uGame = game.NewUserQuickPlayLogin("Jack");
            uGame.GetInRoom();
            var info = uGame.RevealCards();
            Assert.False(info.GetVoteInfo().players[1].vote == -1);
            //if the votes are revealed before the users vote, the vote values become -1
            //apparently the second user (using his own cookie) can Reveal the cards; this should not happen normally
            //thus vote values are -1 for both players in the room
            //test fails because of this
        }
    }
}
