Feature: Walkable Map for Clients 
As a front-room staff member, 
I want to provide clients with a walkable map of services, 
So that they can easily locate and access the services they need.

Scenario: Generating a Walkable Map Given I have a list of services for a client, When I request a walkable map for these services, Then I should receive a map that can be printed or sent to the client's phone.

Given a list of services with location information,
When I request a map for these locations,
Then the directory should generate a walkable map that can be shared with the client.