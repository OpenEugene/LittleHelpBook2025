Feature: Search for Safety-Net Services
As a front-room staff member, 
I want to search for safety-net services, 
So that I can find the most suitable services for clients quickly.

Scenario: Conducting a Provider Search 
Given a directory with a variety of safety-net providers,
When I search using specific parameters,
Then the directory should provide a list of matching providers.

Scenario: Full text Provider Search
Given a directory with a variety of safety-net providers,
When I search using a full text search,
Then the directory should provide a list of matching providers.

Scenario: filter by catagor and sub catagory
Given a directory with a variety of safety-net providers,
When I search using a catagory and sub catagory,
Then the directory should provide a list of matching providers.



