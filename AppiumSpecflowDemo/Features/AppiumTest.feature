Feature: AppiumTest

A demo feature to demonstrate Appium, SpecFlow with c#

@test
Scenario: Appium Demo Scenario
	Given I enroll device
	And I enter password and login
		| password |
		| 200      |
	When I add table with '<NumberOfGuests>' guests
	And I search and select the item '<Item>'
	And I validate that the item '<SelectedItem>' has been added
	Then I pay with exact cash and close the order
	And I verify that table '<Table>' is available
	Examples: 
	| NumberOfGuests | Item         | SelectedItem | Table |
	| 1              | Quick Burger | Quick Burger | 2     |
	| 2              | 7 UP         | Quick Burger | 2     |


	