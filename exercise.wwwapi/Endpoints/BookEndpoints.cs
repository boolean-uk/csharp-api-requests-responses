using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Threading.Tasks;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapGet("/", GetAllBooks);
            bookGroup.MapPost("/", CreateBook);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
            bookGroup.MapPut("/{id}", UpdateBook);
        }

        public static IResult GetAllBooks(IBookRepository books)
        {
            return TypedResults.Ok(books.GetAllBooks());
        }

        public static IResult GetBook(IBookRepository books, int id)
        {
            try
            {
                Book b = books.GetBook(id);
                if (b == null)
                {
                    return Results.NotFound($"Book with id {id} not found.");
                }
                return Results.Ok(b);

            } catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
        }

        public static IResult DeleteBook(IBookRepository books, int id)
        {
            try
            {
                Book b = books.DeleteBook(id);
                if (b == null)
                {
                    return Results.NotFound($"Book with id {id} not found.");
                }
                return Results.Ok(b);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }

        public static IResult CreateBook(IBookRepository books, BookPostPayload newBookData)
        {
            if(newBookData.title.Length == 0 || newBookData.genre.Length == 0 || newBookData.author.Length == 0 || newBookData.numPages < 1) 
            {
                return Results.NotFound($"Book needs all the fields provided to be created!");
            }

            Book b = books.AddBook(newBookData.title, newBookData.numPages, newBookData.author, newBookData.genre);
            return TypedResults.Created($"/books{b.Id}", b);

        }

        public static IResult UpdateBook(IBookRepository books, int id, BookUpdatePayload newBookData)
        {

            try
            {
                Book? b = books.UpdateBook(id, newBookData);
                
                if (b == null)
                {
                    return Results.NotFound($"Book with id {id} not found.");
                }
                return TypedResults.Created($"/students{b}", b);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }
    }
}
