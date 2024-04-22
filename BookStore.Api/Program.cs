using BookStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetBook";

List<BookDto> books = [
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

// GET /books
app.MapGet("books", () => books);

// GET /books/1
app.MapGet("books/{id}", (int id) => books.Find(book => book.Id == id))
    .WithName(GetGameEndpointName);

// POST /books
app.MapPost("books", (CreateBookDto newBook) =>
{
    BookDto book = new(
        books.Count + 1,
        newBook.Name,
        newBook.Genre,
        newBook.Price,
        newBook.Author,
        newBook.ReleaseDate);

    books.Add(book);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = book.Id }, book);
});

app.MapGet("/", () => "Hello World!");

app.Run();
