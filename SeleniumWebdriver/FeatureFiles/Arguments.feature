Feature: Arguments
	To demo passing of argument value from the feature file
	

Background: Pre-Condition
	# Given Stpe
	Given User is at Home Page with url "http://localhost:5001/"
	And File a Bug should be visible

#@Smoke
Scenario: Login scenario of BugZilla
	# Steps - A Given Step
	When I click on "File a Bug" Link
	Then User should be at Login Page with title "Log in to Bugzilla"
	When I provide the "rahul@bugzila.com", "rathore" and click on Login button
	Then User Should be at Enter Bug page with title "Enter Bug"
	When I click on Logout button at enter bug page
	Then User should be logged out and should be at Home Page

Scenario: Create Bug scenario of Bugzilla
	When I click on "File a Bug" Link
	Then User should be at Login Page with title "Log in to Bugzilla1"
	When I provide the "rahul@bugzila.com", "rathore" and click on Login button
	Then User Should be at Enter Bug page with title "Enter Bug"
	When I click on Testng link in the page
	Then User Should be at Bug Detail page with title "Enter Bug: Testng"
	When I provide the severity , harware , platform , summary and desc
	| Severity | Harware   | Platform | Summary     | Desc     |
	| critical | Macintosh | Other    | Summary - 1 | Desc - 1 |
	| major    | Other     | Linux    | Summary - 2 | Desc - 2 |
	And click on Submit button in page
	Then Bug should get created
	And User should be at Search page
	When I click on Logout button at bug detail page
	Then User should be logged out and should be at Home Page
@ignore
Scenario Outline: Create Bug scenario of Bugzilla with scenario outline
	When I click on "<flink>" Link
	Then User should be at Login Page with title "<lTitle>"
	When I provide the "<user>", "<pass>" and click on Login button
	Then User Should be at Enter Bug page with title "<eTitle>"
	When I click on Testng link in the page
	Then User Should be at Bug Detail page with title "<bTitle>"
	When I provide the "<Severity>" , "<Harware>" , "<Platform>" , "<Summary>" and "<Desc>"
	And click on Submit button in page
	Then Bug should get created
	And User should be at Search page
	When I click on Logout button at bug detail page
	Then User should be logged out and should be at Home Page
	Examples: 
	| TestCase | flink      | lTitle             | user              | pass    | eTitle    | bTitle            | Severity | Harware   | Platform | Summary     | Desc     |
	| A        | File a Bug | Log in to Bugzilla | rahul@bugzila.com | rathore | Enter Bug | Enter Bug: Testng | critical | Macintosh | Other    | Summary - 1 | Desc - 1 |
	| B        | File a Bug | Log in to Bugzilla | rahul@bugzila.com | rathore | Enter Bug | Enter Bug: Testng | major    | Other     | Linux    | Summary - 2 | Desc - 2 |