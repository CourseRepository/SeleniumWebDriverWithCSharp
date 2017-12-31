Feature: TestFeature2
	
Background: Pre-Condition
	# Given Stpe
	Given User is at Home Page
	And File a Bug should be visible

Scenario: Login scenario of BugZilla
	# Steps - A Given Step
	When I click on File a Bug Link
	Then User should be at Login Page
	When I provide the "rahul@bugzila.com", "rathore" and click on Login button
	Then User Should be at Enter Bug page
	When I click on Logout button
	Then User should be logged out and should be at Home Page