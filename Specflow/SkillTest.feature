Feature:  Skill Tab Test scenarios

As a Mars portal user 
I would like to create,edit and delete skill records
so that I can manage my skill profile successfully

@tag1
Scenario: create Skill record with data
	Given I logged into Mars portal 
	And I navigate to Skill tab
	When I add a skill "<Skill>" and level "<Level>"
	Then the new "<Skill>" record should be created successfully

	Examples: 
	| Skill   | Level        |
	| C#      | Beginner     |
	|         | Intermediate |
	| X23     |              |
	| Math    | Expert       |

	Scenario: Edit Skill record with new data
	Given I logged into Mars portal 
	And I navigate to Skill tab
	When I edit an existing skill "<Updated Skill>" and level "<Updated Level>"
	Then the new "<Updated Skill>" record should be displayed successfully

	Examples: 
	| Updated Skill		| Updated Level     |
	| Sewing			| Beginner			|
	| Baking			| Expert			|

	Scenario Outline: delete an existing Skill record 
	Given I logged into Mars portal
	And I navigate to Skill tab
	When I have an existing skill record to delete
	Then the skill record should be deleted successfully