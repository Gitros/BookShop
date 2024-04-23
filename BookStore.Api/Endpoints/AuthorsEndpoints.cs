using BookStore.Api.Data;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

public static class AuthorsEndpoints
{
    public static RouteGroupBuilder MapAuthorsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("authors");

        group.MapGet("/", async (BookStoreContext dbContext) =>
            await dbContext.Authors
                            .Select(author => author.ToDto())
                            .AsNoTracking()
                            .ToListAsync());
        return group;
    }
}
