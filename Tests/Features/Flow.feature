Feature: Flow
	As a user of Dnipro store
	I want to be able to create account and make an order

Background: 
	Given I create user in store
		| Name           | Age | Email                  | Address |
		| Lord Voldemort | 45  | avadakedavra@gmail.com | London  |
	And I add 'Pandemia' book to store

Scenario: Usual positive flow
	When I add 'Pandemia' book to Lord Voldemort user cart
	And I create order from Lord Voldemort user cart
	Then I check Lord Voldemort user order presence in store

	When I delete Lord Voldemort user
	And I delete 'Pandemia' book from store