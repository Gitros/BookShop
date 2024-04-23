using BookStore.Api.Dtos;

namespace BookStore.Api.Endpoints;

public static class BooksEndpoints
{
    const string GetBookEndpointName = "GetBook";
    private static readonly List<BookDto> books = [
    new (
        1,
        "Harry Potter",
        "Fantasy",
        20.51m,
        "J.K Rolling",
        new DateOnly(2018, 9, 12)),
    new (
        2,
        "Death Note",
        "Manga",
        16.99m,
        "Tsugumi Ōby",
        new DateOnly(2010, 2, 19)),
    new (
        3,
        "Wiedźmin",
        "Fantasy",
        10.98m,
        "Andrzej Sapkowski",
        new DateOnly(2009, 8, 24))
    ];

    public static RouteGroupBuilder MapBooksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("books");

        // GET /books
        group.MapGet("/", () => books);

        // GET /books/1
        group.MapGet("/{id}", (int id) =>
        {
            BookDto? book = books.Find(book => book.Id == id);

            return book is null ? Results.NotFound() : Results.Ok(book);
        })
        .WithName(GetBookEndpointName);

        // POST /books
        group.MapPost("/", (CreateBookDto newBook) =>
        {
            BookDto book = new(
                books.Count + 1,
                newBook.Name,
                newBook.Genre,
                newBook.Price,
                newBook.Author,
                newBook.ReleaseDate);

            books.Add(book);

            return Results.CreatedAtRoute(GetBookEndpointName, new { id = book.Id }, book);
        });

        // PUT /books/1
        group.MapPut("/{id}", (int id, UpdateBookDto updatedBook) =>
        {
            var index = books.FindIndex(book => book.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            books[index] = new BookDto(
                id,
                updatedBook.Name,
                updatedBook.Genre,
                updatedBook.Price,
                updatedBook.Author,
                updatedBook.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /book/
        group.MapDelete("/{id}", (int id) =>
        {
            books.RemoveAll(book => book.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
