using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("/books");
            bookGroup.MapGet("/", GetAll);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPost("/", AddBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        public static IResult GetAll(IBookRepository books)
        {
            return TypedResults.Ok(books.GetBooks());
        }

        public static IResult GetBook(IBookRepository books, int id)
        {
            Book book = books.GetBook(id);
            if (book == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(book);
        }

        public static IResult AddBook(IBookRepository books, BookCreatePayload bookData)
        {
            Book book = books.AddBook(bookData);
            return TypedResults.Created($"/books/{book.Id}", book);
        }

        public static IResult UpdateBook(IBookRepository books, int id, BookUpdatePayload bookData)
        {
            Book book = books.UpdateBook(id, bookData);
            if (book == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(book);
        }

        public static IResult DeleteBook(IBookRepository books, int id)
        {
            Book book = books.DeleteBook(id);
            if (book == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok();
        }
    }
}
