Feature: Collection of Safety-Net Services
As a front-room staff member, 
I want to create a collection of safety-net services, 
So that I can have a curated list of services ready for clients.

Scenario: Creating a Service Collection Given I am using the safety-net service directory, When I select multiple services to add to a collection, Then I should be able to save and name this collection for future reference.
Given a selection of safety-net services,
When I choose certain services for a collection,
Then the directory should allow me to save this collection with a custom name.