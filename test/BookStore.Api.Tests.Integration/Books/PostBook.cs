using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BookStore.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BookStore.Api.Tests.Integration;

public class PostBook
{
  [Fact]
  public async Task InsertsBookInDatabase()
  {
    // arrange
    var factory = new WebApplicationFactory<Program>();
    var httpClient = factory.CreateClient();
    var request = new HttpRequestMessage
    {
      Method = HttpMethod.Post,
      RequestUri = new System.Uri("books", System.UriKind.Relative)
    };

    // act
    var response = await httpClient.SendAsync(request);

    // assert
    response.StatusCode.Should().Be(HttpStatusCode.Created);
  }
}
