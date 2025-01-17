using exercise.wwwapi.Extension.Books.Model;
using exercise.wwwapi.Extension.Books.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Extension.Books.Endpoint
{
    public static class BooksEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetBooks);
            books.MapGet("/{id}", GetSingleBook);
            books.MapPost("/", AddBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            var books = repository.GetBooks();
            return Results.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetSingleBook(IBookRepository repository, int id)
        {
            var book = repository.GetSingleBook(id);
            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository repository, BookDTO bookDto)
        {
            var book = new Book()
            {
                title = bookDto.title,
                numPages = bookDto.numPages,
                author = bookDto.author,
                genre = bookDto.genre
            };

            var addedBook = repository.AddBook(book);
            return Results.Created($"https://localhost:7068/books/{addedBook.Id}", addedBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, BookDTO updatedBook)
        {

            var book = new Book()
            {
                title = updatedBook.title,
                numPages = updatedBook.numPages,
                author = updatedBook.author,
                genre = updatedBook.genre
            };

            var result = repository.UpdateBook(id, book);
            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {;
            var deletedBook = repository.DeleteBook(id);

            return Results.Ok(deletedBook);
        }
    }
}
