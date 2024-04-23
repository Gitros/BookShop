namespace BookStore.Api.Entities;

public class Book
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    public decimal Price { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
