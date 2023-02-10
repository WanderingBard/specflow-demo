Feature: PlaceForecast

Get the current weather forecast for a particular place name such as a country

@tag1
#Scenario: Get a weather forecast for Scotland
#	Given the country name is Scotland
#	When The get place forecast is called
#	Then the summary is Freezing

#Scenario: Get a weather forecast for England
#	Given the country name is Scotland
#	When The get place forecast is called
#	Then the summary is Chilly

Scenario: Get a weather forecast for a country
	Given the country name is <Country>
	When The get place forecast is called
	Then the summary is <Summary>

Examples: 
	| Country  | Summary  |
	| Scotland | Freezing |
	| England  | Chilly   |