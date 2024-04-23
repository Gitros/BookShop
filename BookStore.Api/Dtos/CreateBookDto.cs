using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Dtos;

public record class CreateBookDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1, 100)] decimal Price,
    int AuthorId,
    DateOnly ReleaseDate
    );
