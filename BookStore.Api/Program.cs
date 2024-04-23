using BookStore.Api.Data;
using BookStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = "Data Source=BookStore.db";
builder.Services.AddSqlite<BookStoreContext>(connString);

var app = builder.Build();

app.MapBooksEndpoints();

app.Run();
