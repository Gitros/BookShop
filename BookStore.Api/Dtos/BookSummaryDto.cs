namespace BookStore.Api.Dtos;

public record class BookSummaryDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    string Author,
    DateOnly ReleaseDate);