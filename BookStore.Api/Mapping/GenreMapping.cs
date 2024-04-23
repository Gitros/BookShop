using BookStore.Api.Dtos;
using BookStore.Api.Entities;

namespace BookStore.Api.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}
