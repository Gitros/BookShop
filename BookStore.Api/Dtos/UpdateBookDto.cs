using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Dtos;

public record class UpdateBookDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    [Required][StringLength(30)] string Author,
    DateOnly ReleaseDate
);
