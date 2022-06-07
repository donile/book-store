using BookStore.Api.Database;

namespace BookStore.Api.Books;

public class Repository<T>
{
  private readonly BookStoreDbContext _db;

  public Repository(BookStoreDbContext db)
  {
    _db = db;
  }

  public void Insert(T item)
  {
    _db.Add(item);
  }

  public void SaveChanges()
  {
    _db.SaveChanges();
  }
}
