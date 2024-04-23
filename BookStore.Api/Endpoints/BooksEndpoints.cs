using BookStore.Api.Data;
using BookStore.Api.Dtos;
using BookStore.Api.Entities;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Endpoints;

public static class BooksEndpoints
{
    const string GetBookEndpointName = "GetBook";
    private static readonly List<BookSummaryDto> books = [
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
        var group = app.MapGroup("books")
                        .WithParameterValidation();

        // GET /books
        group.MapGet("/", () => books);

        // GET /books/1
        group.MapGet("/{id}", (int id, BookStoreContext dbContext) =>
        {
            Book? book = dbContext.Books.Find(id);

            return book is null ? Results.NotFound() : Results.Ok(book.ToBookDetailsDto());
        })
        .WithName(GetBookEndpointName);

        // POST /books
        group.MapPost("/", (CreateBookDto newBook, BookStoreContext dbContext) =>
        {
            Book book = newBook.ToEntity();

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetBookEndpointName, new { id = book.Id }, book.ToBookDetailsDto());
        });

        // PUT /books/id
        group.MapPut("/{id}", (int id, UpdateBookDto updatedBook, BookStoreContext dbContext) =>
        {
            var existingBook = dbContext.Books.Find(id);

            if (existingBook is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingBook)
                            .CurrentValues
                            .SetValues(updatedBook.ToEntity(id));

            dbContext.SaveChanges();

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
