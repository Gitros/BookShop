namespace BookStore.Api.Dtos;

public record class CreateBookDto(
    string Name,
    string Genre,
    decimal Price,
    string Author,
    DateOnly ReleaseDate);
