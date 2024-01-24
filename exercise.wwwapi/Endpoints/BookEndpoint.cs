using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void BookLogics(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapGet("/", GetAllBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPost("/", CreateBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        public static IResult GetAllBooks(IBookRepository books)
        {
            return TypedResults.Ok(books.GetAllBooks());
        }

        public static IResult GetBook(IBookRepository books, int id)
        {
            Book? book = books.GetBook(id);
            if (book == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(books.GetBook(id));
        }

        public static IResult CreateBook(IBookRepository books, BookPostPayload createdBook)
        {
            Book? newBook = books.AddBook(createdBook.title, createdBook.numPages, createdBook.author, createdBook.genre);
            if (newBook == null)
                return Results.NotFound("Could not create student");

            return TypedResults.Created($"/books{newBook.Title} {newBook.NumPages} {newBook.Author} {newBook.Genre}", newBook);
        }

        public static IResult UpdateBook(IBookRepository books, BookUpdatePayload posted, int id)
        {
            Book? book = books.GetBook(id);
            if (book == null)
                return Results.NotFound("ID out of scope");

            book = books.UpdateBook(book, posted);
            return TypedResults.Created($"/books{book.Title} {book.NumPages} {book.Author} {book.Genre}", book);
        }

        public static IResult DeleteBook(IBookRepository books, int id)
        {
            Book? book = books.GetBook(id);
            if (book == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(books.DeleteBook(id));
        }
    }
}
