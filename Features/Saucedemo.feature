Feature: Saucedemo

	As an end user i want to be able to add item 
	into a basket and verify total item count.

@tag1
Scenario: Verify total basket count
	Given I am on SwagLab login page
	And I enter the following credentials
	| username      | password     |
	| standard_user | secret_sauce |
	When I click login button
	Then I am on product page
	When I add item to cart
	And I click the basket
	Then total item in cart is 3
