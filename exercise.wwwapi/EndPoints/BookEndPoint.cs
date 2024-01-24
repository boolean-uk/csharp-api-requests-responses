using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndPoint
    {
        public static void ConfigureBookEndPoint(this WebApplication app)
        {
            var BookGroup = app.MapGroup("/books");
            BookGroup.MapGet("/", GetAllBooks);
            BookGroup.MapPost("/", AddBook);
            BookGroup.MapGet("/{id}", GetBook);
            BookGroup.MapDelete("/{id}", DeleteBook);
            BookGroup.MapPut("/{id}", UpdateBook);
        }

        public static IResult GetAllBooks(IBookRepository bookRepository)
        {
            try
            {
                return TypedResults.Ok(bookRepository.GetAllBooks());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult AddBook(IBookRepository bookRepository, string title, int numPage, string author, string genre)
        {
            try
            {
                Book book = bookRepository.AddBook(title, numPage, author, genre);
                return TypedResults.Created($"/books/{book.Id}", book);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    
        public static IResult GetBook(IBookRepository bookRepository, int id)
        {
            try
            {
                Book? book = bookRepository.GetBook(id);
                if (book == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(book);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static IResult DeleteBook(IBookRepository bookRepository, int id)
        {
            try
            {
                Book? book = bookRepository.DeleteBook(id);
                if (book == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(book);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static IResult UpdateBook(IBookRepository bookRepository, int id, BookUpdatePayload bookUpdatePayload)
        {
            try
            {
                Book? book = bookRepository.UpdateBook(id, bookUpdatePayload);
                if (book == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(book);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}