Feature: Collection of Safety-Net Services
As a front-room staff member, 
I want to create a collection of safety-net services, 
So that I can have a curated list of services ready for clients.

Scenario: Creating a Service Collection 
Given a selection of safety-net providers,
When I choose certain services for a collection,
Then the directory should allow me to save this collection with a custom name.

Scenario: Save a Service Collection for later.
Given a collection I've created
When I save the collection
And give it a name
Then I should be able to access the collection later

Scenario: List saved collections.
Given I have saved collections
When I go to the directory
Then I should be able to see a list of my saved collections




