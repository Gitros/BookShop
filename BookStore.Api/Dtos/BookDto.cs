namespace BookStore.Api.Dtos;

public record class BookDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    string Author,
    DateOnly ReleaseDate);