using BookStore.Api.Dtos;
using BookStore.Api.Entities;

namespace BookStore.Api.Mapping;

public static class AuthorMapping
{
    public static AuthorDto ToDto(this Author author)
    {
        return new AuthorDto(author.Id, author.Name);
    }
}
