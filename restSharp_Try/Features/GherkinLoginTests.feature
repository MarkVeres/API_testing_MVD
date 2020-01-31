Feature: GherkinLoginTests
	In order to check if I login succesfully
	As I cannot see the UI
	I want to be told if the name of the game room is correct

@mytag
Scenario: UserLoginByQuickPlay
	Given I have logged in via QuickPlay
	When I Create a Game Room
	When I request Room Information
	Then The Game Room name should be the one I Created the Room with
