Feature: Login and Create Bug Feature of the BugZila web page

Background: Pre-Condition
	# Given Stpe
	Given User is at Home Page
	And File a Bug should be visible

Scenario: Login scenario of BugZilla
	# Steps - A Given Step
	When I click on File a Bug Link
	Then User should be at Login Page
	When I provide the username, password and click on Login button
	Then User Should be at Enter Bug page
	When I click on Logout button
	Then User should be logged out and should be at Home Page


Scenario: Create Bug scenario of Bugzilla
	When I click on File a Bug Link
	# Then Step
	Then User should be at Login Page
	When I provide the username, password and click on Login button
	Then User Should be at Enter Bug page
	When I click on  Testng link
	Then User Should be at Bug Detail page
	When I provide the severity , harware , platform and summary
	And click on Submit button
	Then Bug should get created
	And User should be at Search page
	When I click on Logout button
	Then User should be logged out and should be at Home Page