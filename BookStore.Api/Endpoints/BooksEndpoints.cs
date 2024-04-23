using BookStore.Api.Data;
using BookStore.Api.Dtos;
using BookStore.Api.Entities;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Endpoints;

public static class BooksEndpoints
{
    const string GetBookEndpointName = "GetBook";

    public static RouteGroupBuilder MapBooksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("books")
                        .WithParameterValidation();

        // GET /books
        group.MapGet("/", (BookStoreContext dbContext) =>
            dbContext.Books
                     .Include(book => book.Genre)
                     .Include(book => book.Author)
                     .Select(book => book.ToBookSummaryDto())
                     .AsNoTracking());

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
        group.MapDelete("/{id}", (int id, BookStoreContext dbContext) =>
        {
            dbContext.Books
                    .Where(book => book.Id == id)
                    .ExecuteDelete();

            return Results.NoContent();
        });

        return group;
    }
}
