namespace BookStore.Api.Dtos;

public record class BookDetailsDto(
    int Id,
    string Name,
    int GenreId,
    decimal Price,
    int AuthorId,
    DateOnly ReleaseDate);