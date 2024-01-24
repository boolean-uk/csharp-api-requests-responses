
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Models.Payload;

namespace exercise.Endpoints {
    public static class BookEndpoints { 
         public static void ConfigureBookEndpoint(this WebApplication app) {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{title}", GetBook);
            books.MapPost("/", CreateBook);
            books.MapPut("/{name}", UpdateBook);
            books.MapDelete("/{name}", DeleteBook);
        }

        private static IResult CreateBook(IBookRepository br, BookPostPayload payload)
        {
            if (payload == null)
            {
                return Results.BadRequest("Payload cannot be null");
            }

            Book book = br.AddBook(payload.title, payload.numPages, payload.author, payload.genre);
            return TypedResults.Created($"/tasks/{book.Title}", book);
        }

        public static IResult GetAllBooks(IBookRepository br)
        {
            return TypedResults.Ok(br.GetAllBooks());
        }

        public static IResult GetBook(IBookRepository br, string Title)
        {
            var book = br.GetBook(Title);

            if (book == null)
            {
                return Results.NotFound($"Book with Title {Title} not found.");
            }

            return TypedResults.Ok(book);
        }

        public static IResult DeleteBook(IBookRepository br, string Title)
        {
            var deletedBook = br.DeleteBook(Title);

            if (deletedBook == null)
            {
                return Results.NotFound($"Book with Title {Title} not found.");
            }

            return TypedResults.Ok(deletedBook);
        }

        public static IResult UpdateBook(IBookRepository br, string Title, BookUpdatePayload payload)
        {
            try
            {
                if (payload == null)
                {
                    return Results.BadRequest("Payload cannot be null");
                }

                Book? book = br.UpdateBook(Title, payload);

                if (book == null)
                {
                    return Results.NotFound($"Book with Title {Title} not found.");
                }

                return Results.Ok(book);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
