using BookStore.Api.Dtos;
using BookStore.Api.Entities;

namespace BookStore.Api.Mapping;

public static class BookMapping
{
    public static Book ToEntity(this CreateBookDto book)
    {
        return new Book()
        {
            Name = book.Name,
            GenreId = book.GenreId,
            Price = book.Price,
            AuthorId = book.AuthorId,
            ReleaseDate = book.ReleaseDate
        };
    }

    public static BookDto ToDto(this Book book)
    {
        return new(
            book.Id,
            book.Name,
            book.Genre!.Name,
            book.Price,
            book.Author!.Name,
            book.ReleaseDate
        );
    }
}
