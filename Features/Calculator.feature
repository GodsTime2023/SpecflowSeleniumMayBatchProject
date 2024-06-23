Feature: Calculator

As an end user i should be able to 
perform a calculator function


@ignore
Scenario: Add two numbers
	Given I am on Calculator demo page
	And the "first" number is "50"
	And the "second" number is "70"
	When the two numbers are added
	Then the result should be "120"

Scenario Outline: Add two numbers with multiple examples
	Given I am on Calculator demo page
	And the "first" number is "<FirstNumber>"
	And the "second" number is "<SecondNumber>"
	When the two numbers are added
	Then the result should be "<Result>"
Examples: 
| FirstNumber | SecondNumber | Result |
| 5.5         | 7.5          | 12     |
| 50          | 70           | 120    |
| 70          | 60           | 130    |
| 100         | 70           | 170    |
| 50          | 200          | 250    |
| 10          | 90           | 100    |
| 1000        | 1000         | 2000   |