Feature: Safety-Net Service Directory
As a front-room staff member, 
I want to access a comprehensive directory of safety-net services, 
So that I can quickly find and refer clients to the appropriate services.

Scenario: Searching for a Service Given I have access to the safety-net service directory, When I search for a service by category, location, or eligibility, Then I should see a list of services that match my search criteria.
Given a populated directory of services,
When the user inputs search parameters,
Then the directory should return all relevant services.
	
Scenario: Adding a New Service Listing Given I am an authorized staff member, When I enter details for a new safety-net service, Then the service should be added to the directory and be searchable.
Given the user has the necessary permissions,
When they submit a new service listing,
Then the directory should update to include the new service.
	
Scenario: Updating an Existing Service Listing Given I am viewing a service listing, When I edit the information and save the changes, Then the updated details should be reflected in the directory.
Given an existing service listing,
When an authorized user makes changes,
Then the directory should save and display the updated information.
	
Scenario: Removing a Service Listing Given I have identified a service that is no longer available, When I remove the service from the directory, Then the service should no longer appear in any search results.
Given a service is identified as obsolete,
When an authorized user removes the listing,
Then the directory should no longer include that service.
