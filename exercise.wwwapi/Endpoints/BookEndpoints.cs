using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("books");
            taskGroup.MapGet("/", GetBooks);
            taskGroup.MapGet("/{id}", GetBooksByID);
            taskGroup.MapPost("/", AddBook);
            taskGroup.MapPut("/{id}", UpdateBook);
            taskGroup.MapDelete("/{id}", DeleteBook);
        }

        public static IResult GetBooks(IBookRepository books)
        {
            return TypedResults.Ok(books.GetAllBooks());
        }
        public static IResult GetBooksByID(IBookRepository books, int id)
        {
            Book? result = books.GetById(id);
            if (result == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(result);
        }

        public static IResult AddBook(IBookRepository books, BookPayload data)
        {
            Book result = books.AddBook(data);
            return TypedResults.Created("", result);
        }

        public static IResult UpdateBook(IBookRepository books, int id, BookUpdatePayload data)
        {
            try
            {
                return TypedResults.Created("", books.UpdateBook(id, data));
            }
            catch
            {
                return TypedResults.NotFound();
            }
        }
        public static IResult DeleteBook(IBookRepository books, int id)
        {
            try
            {
                return TypedResults.Created("", books.DeleteBook(id));
            }
            catch
            {
                return TypedResults.NotFound();
            }
        }

    }
}
