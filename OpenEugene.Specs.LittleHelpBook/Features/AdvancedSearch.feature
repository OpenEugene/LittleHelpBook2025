Feature: Advanced Search Filters 
As a front-room staff member, 
I want to use advanced search filters, 
So that I can narrow down the search results to the most relevant services for clients.

Scenario: Using Category Filters Given I am on the search page of the safety-net service directory, When I apply filters for specific categories and sub-categories, Then I should see services that match the selected categories and sub-categories.
Given the directory has a comprehensive list of categories and sub-categories,
When I select specific categories and sub-categories,
Then the search results should reflect services under those categories and sub-categories.

Scenario: Combining Multiple Filters Given I have selected a category, When I apply additional filters like location, eligibility, and service type, Then I should see services that match all the applied filters.
Given a variety of filters are available,
When I combine multiple filters for a search,
Then the directory should provide a list of services that meet all the criteria.

Scenario: Saving Filtered Searches Given I have applied a set of filters for a search, When I save this filtered search for future use, Then I should be able to access this search quickly without reapplying the filters.
Given a set of applied filters,
When I choose to save the search,
Then the directory should allow me to retrieve the same filtered results later.
