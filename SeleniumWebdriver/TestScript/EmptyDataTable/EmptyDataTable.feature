Feature: EmptyDataTable

Scenario Outline: To test the data example with empty column vlaue
	Given User read "<name>" and "<password>" from examples
	Examples: 
		| name | password |
		| pqr  | sdf      |
		| abc  |          |
		|      | fgh      |