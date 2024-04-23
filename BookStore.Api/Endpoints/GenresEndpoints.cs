using BookStore.Api.Data;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (BookStoreContext dbContext) =>
            await dbContext.Genres
                            .Select(genre => genre.ToDto())
                            .AsNoTracking()
                            .ToListAsync());

        return group;
    }
}
