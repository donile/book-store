using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Books;

[ApiController]
[Route("/books")]
public class BookController : ControllerBase
{
  [HttpPost]
  public ActionResult PostBook()
  {
    var route = Url.RouteUrl(nameof(GetBook), new { bookId = Guid.NewGuid() });

    return Created(route!, null);
  }

  [HttpGet("{bookId}", Name = nameof(GetBook))]
  public IActionResult GetBook(Guid bookId)
  {
    var book = new Book
    {
      Author = "author",
      Title = "title"
    };

    return Ok(book);
  }
}
