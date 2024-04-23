using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options)
    : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<Author> Authors => Set<Author>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Manga" },
            new { Id = 2, Name = "Fantasy" },
            new { Id = 3, Name = "History" },
            new { Id = 4, Name = "Educational" },
            new { Id = 5, Name = "Science" }
        );

        modelBuilder.Entity<Author>().HasData(
            new { Id = 1, Name = "J.K Rolling" },
            new { Id = 2, Name = "Tsugumi Ōby" },
            new { Id = 3, Name = "Andrzej Sapkowski" },
            new { Id = 4, Name = "David McCullough" },
            new { Id = 5, Name = "Bill Bryson" }
        );
    }
}
