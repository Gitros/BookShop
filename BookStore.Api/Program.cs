using BookStore.Api.Data;
using BookStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BookStore");
builder.Services.AddSqlite<BookStoreContext>(connString);

var app = builder.Build();

app.MapBooksEndpoints();
app.MapGenresEndpoints();
app.MapAuthorsEndpoints();

await app.MigrateDbAsync();

app.Run();
