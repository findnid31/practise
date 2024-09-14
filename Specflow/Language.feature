Feature: Language Tab Test scenarios

As a Mars portal user 
I would like to create,edit and delete language records
so that I can manage my language profile successfully


@TS01 @TC04 @HappyPath
Scenario Outline: create language record with data
	Given I logged into Mars portal successfully
	When I add a language "<Language>" and language level "<Level>"
	Then the "<Language>" record should be created successfully

	Examples: 
	| Language | Level          |
	| English  | Fluent         |
	| SPANISH  | Native         |
	| 4152     | Native         |
	|          | Fluent         |
	| Mandarin |                |
	| Hindi    | Conversational |


	@TS01 @HappyPath
Scenario Outline: edit language record with data
	Given I logged into Mars portal successfully
	When I edit an existing language to "<Updated Language>" and level to "<Updated Level>"
	Then new "<Updated Language>" record should be displayed successfully

	Examples: 
	| Updated Language | Updated level |
	| SPANISH          | Native        |
	|   5487           | Conversational|
	| English          | Fluent        |



	@tag1
Scenario Outline: delete language record with valid data
	Given I logged into Mars portal successfully
	When I have an existing record to delete
	Then the record should be deleted successfully

	