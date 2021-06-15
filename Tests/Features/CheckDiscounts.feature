Feature: CheckDiscounts
	Simple calculator for adding two numbers

@mytag
Scenario: Check disounts
    When I open Main page
	Then Main page is opened
	When I navigate categories in the top menu
	Given Click Action games
	Then Main page is opened
	When I get the game with the lowest discount

