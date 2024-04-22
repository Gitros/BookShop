namespace BookStore.Api.Dtos;

public record class UpdateBookDto(
    string Name,
    string Genre,
    decimal Price,
    string Author,
    DateOnly ReleaseDate);
