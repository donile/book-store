using BookStore.Api.Books;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Database;

public class BookStoreDbContext : DbContext
{
  public DbSet<Book>? Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options
      .UseNpgsql("Server=postgres;Database=postgres;User Id=postgres;Password=postgres")
      .UseSnakeCaseNamingConvention();
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    new BookEntityTypeConfiguration().Configure(builder.Entity<Book>());
  }
}
