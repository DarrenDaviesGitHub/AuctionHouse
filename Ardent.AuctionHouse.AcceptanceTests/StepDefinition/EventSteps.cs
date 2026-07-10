using Ardent.AuctionHouse.AcceptanceTests.Context;
using Ardent.AuctionHouse.AcceptanceTests.Models;
using FluentAssertions;
using Reqnroll;
using System.Net.Http.Json;

namespace Ardent.AuctionHouse.AcceptanceTests.StepDefinition;

[Binding]
public sealed class EventWhenSteps
{
    private readonly ApiScenarioContext _context;

    public EventWhenSteps(ApiScenarioContext context)
    {
        _context = context;
    }

    [Given("I am a third party consuming the API")]
    public async Task GivenWhenIAmAThirdPartyConsumingTheAPI()
    {
    }

    [When("I request all events")]
    public async Task WhenIRequestAllEvents()
    {
        _context.Response = await _context.Client.GetAsync("/api/events");
    }

    [When("I request an event with event id (.*)")]
    public async Task WhenIRequestAllEvents(Guid eventId)
    {
        _context.Response = await _context.Client.GetAsync($"/api/events/{eventId}");
    }

    [When("I request an event that does not exist")]
    public async Task WhenIRequestAnEventThatDoesNotExist()
    {
        Guid eventId = Guid.NewGuid();
        _context.Response = await _context.Client.GetAsync($"/api/events/{eventId}");
    }

    [Then("the response should contain a list of events")]
    public async Task TheResponseShouldContainAListOfEvent()
    {
        const short expectedCount = 3;

        var events =
            await _context.Response.Content
                .ReadFromJsonAsync<List<EventDto>>();

        events.Should().NotBeNull();
        events.Should().NotBeEmpty();
        events.Count.Should().Be(expectedCount);
    }

    [Then("the response should contain an event")]
    public async Task TheResponseShouldContainOneEvent()
    {
        var result = await _context.Response.Content
                .ReadFromJsonAsync<EventDto>();

        result.Should().NotBeNull();
        result.Name.Should().NotBeNullOrEmpty();
        result.Location.Should().NotBeNullOrEmpty();
        result.Showings.Should().NotBeNull();
        result.Date.Should().BeAfter(DateTime.MinValue);
    }

    [Then("the response should contain 0 events")]
    public async Task TheResponseShouldContainNoEvents()
    {
        var result = await _context.Response.Content
                .ReadFromJsonAsync<EventDto>();

        result.Should().NotBeNull();
        result.Name.Should().BeNullOrEmpty();
        result.Location.Should().BeNullOrEmpty();
        result.Showings.Should().BeNullOrEmpty();
        result.Date.Should().Be(DateTime.MinValue);
    }

    [Then("the response status code should be 200")]
    public async Task TheResponseStatusCodeShouldBe200()
    {
        _context.Response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the response status code should be 404")]
    public async Task TheResponseStatusCodeShouldBe404()
    {
        _context.Response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }
}