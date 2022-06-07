namespace BookStore.Api.Books
{
  public class Book
  {
    public Guid Id { get; set; }
    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
  }
}
