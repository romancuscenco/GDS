Feature: Ordering answers
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag_is_here
Scenario: The answer with the highest vote gets to the top
	Given There is a question "What's your favourite color?" with the answers
		| Answer | Vote |
		| Red    | 1    |
		| Green  | 1    |
	When you upvote answer "Green"
	Then the answer "Green" should be on top
