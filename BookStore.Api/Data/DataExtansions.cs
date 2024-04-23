using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public static class DataExtansions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
        dbContext.Database.Migrate();
    }
}
