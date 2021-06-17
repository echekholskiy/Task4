Feature: CheckDiscounts
	Methods for testing game discounts

@mytag
Scenario: Check disounts
    When I open Main page
	Then Main page is opened

	When I navigate categories in the top menu
	And Click Action games
	Then Action page is opened

	When I click Top Selling tab
	Then Top selling tab is opened

	Given The game with the lowest discount
	When I Click the game with the lowest discount
	And Enter the correct age on the Rated content if it's shown
	|Name |Value  |
	|Month|January|
	|Year |1994   |
	|Day  |11     |
	Then Game page is opened

	When I check discount of the game
	Then Then discount rate, initial and discounted prices equals to corresponding values


