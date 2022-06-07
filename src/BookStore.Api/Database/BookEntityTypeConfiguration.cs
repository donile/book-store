using BookStore.Api.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Api.Database
{
  internal class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
  {
    public void Configure(EntityTypeBuilder<Book> builder)
    {
      builder
        .ToTable("books")
        .HasKey(b => b.Id);
      
      builder
        .Property(b => b.Author)
        .HasColumnName("author")
        .HasMaxLength(256);
      
      builder
        .Property(b => b.Title)
        .HasColumnName("title")
        .HasMaxLength(256);
    }
  }
}
