using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace BookStore.Api.Tests.Integration;

public class PostBook
{
  [Fact]
  public async Task InsertsBookInDatabase()
  {
    // arrange
    var factory = new CustomWebApplicationFactory<BookStore.Api.Program>();
    var httpClient = factory.CreateClient();
    
    var book = @"
      {
        ""author"": ""author"",
        ""title"": ""title""
      }
    ";

    var request = new HttpRequestMessage
    {
      Method = HttpMethod.Post,
      RequestUri = new System.Uri("books", System.UriKind.Relative),
      Content = new StringContent(book, System.Text.Encoding.UTF8, "application/json")
    };

    // act
    var response = await httpClient.SendAsync(request);

    // assert
    response.StatusCode.Should().Be(HttpStatusCode.Created);
  }
}
