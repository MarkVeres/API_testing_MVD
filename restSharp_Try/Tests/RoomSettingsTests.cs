﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try.Tests
{
    public class RoomSettingsTests
    {
        //these tests check for functions that are not default to room creation
        //more precise they check if the available options regarding room setting are working

        [Fact]
        public void CreateRoomWithoutStories()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoomHaveStories("Test Room", false);
            var info = game.GetRoomInfo();
            Assert.False(info.haveStories);
        }

        [Fact]
        public void SkipStoriesWithoutConfirmation()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoomSkipConfirmation("John", false);
            var info = game.GetRoomInfo();
            Assert.False(info.confirmSkip);
        }

        [Fact]
        public void DontShowVotesToObservers()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoomObserverSeeingVotes("John", false);
            var info = game.GetRoomInfo();
            Assert.False(info.showVotingToObservers);
        }

        [Fact]
        public void NoAutomaticRevealVotes()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoomAutoVoteReveal("John", false);
            var info = game.GetRoomInfo();
            Assert.False(info.autoReveal);
        }

        [Fact]
        public void AllowVoteChangeAfterVoting()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            var game = player.CreateRoomAllowChangeVote("John", true);
            var info = game.GetRoomInfo();
            Assert.True(info.changeVote);
        }

        [Fact]
        public void UseCountdownTimer()
        {
            var client = new PlanitPockerClient();
            var player = client.QuickPlayLogin("John");
            //this next method also requires the duration of the countdown timer in seconds 
            var game = player.UseCountDownTimer("John", true, 30);
            var info = game.GetRoomInfo();
            Assert.True(info.countdownTimer);
        }
    }
}