using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Books;

[ApiController]
[Route("/books")]
public class BookController : ControllerBase
{
  private readonly Repository<Book> _repository;

  public BookController(Repository<Book> repository)
  {
    _repository = repository;
  }

  [HttpPost]
  public ActionResult PostBook(Book book)
  {
    _repository.Insert(book);
    _repository.SaveChanges();

    var route = Url.RouteUrl(nameof(GetBook), new { bookId = book.Id });

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
