Feature: Get Events

Scenario: Get all events
    Given I am a third party consuming the API
    When I request all events
    Then the response should contain a list of events
    And the response status code should be 200

Scenario: Get an event that does exist
    Given I am a third party consuming the API
    When I request an event with event id 123e4567-e89b-12d3-a456-426614174000
    Then the response should contain an event
    And the response status code should be 200

Scenario: Get an event that does not exist
    Given I am a third party consuming the API
    When I request an event that does not exist
    Then the response should contain 0 events
    And the response status code should be 404