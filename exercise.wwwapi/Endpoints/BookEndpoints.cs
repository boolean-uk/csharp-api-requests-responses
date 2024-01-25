using exercise.wwwapi.Models.Language;
using exercise.wwwapi.Repository.Interfaces;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndPoints(this WebApplication app)
        {
            var students = app.MapGroup("/Books");

            students.MapPost("", AddBook);
            students.MapGet("", GetAllBooks);
            students.MapGet("/{book}", GetABook);
            students.MapPatch("/{book}", UpdateBook);
            students.MapDelete("/{book}", DeleteBook);
        }

        public static IResult AddBook(IBookRepo books, BookPayload payLoad)
        {
            if (string.IsNullOrWhiteSpace(payLoad.title)) { return TypedResults.BadRequest("Title can't be empty"); }
            if (payLoad.numPages == 0 || payLoad.numPages == default) { return TypedResults.BadRequest("Nr of pages can't be empty or 0"); }
            if (string.IsNullOrWhiteSpace(payLoad.author)) { return TypedResults.BadRequest("Author can't be empty"); }
            if (string.IsNullOrWhiteSpace(payLoad.genre)) { return TypedResults.BadRequest("Genre can't be empty"); }

            var book = books.Add(payLoad);
            if (book == default) { return TypedResults.BadRequest(book); }
            return book == default ? TypedResults.BadRequest(book) : TypedResults.Created($"/Books/{book.Id}", book);
        }

        public static IResult GetAllBooks(IBookRepo books)
        {
            if (books.GetAll() == null || books.GetAll().Count <= 0) { return TypedResults.NoContent(); }
            return TypedResults.Ok(books.GetAll());
        }

        public static IResult GetABook(IBookRepo books, int id)
        {
            var book = books.Get(id);
            if (book == default) { return TypedResults.NoContent(); };
            return TypedResults.Ok(book);
        }

        public static IResult UpdateBook(IBookRepo books, int id, BookPayload updatePayload)
        {
            if (new[] { updatePayload.title, updatePayload.numPages.ToString(), updatePayload.author, updatePayload.genre }
                .Any(string.IsNullOrWhiteSpace)) { return TypedResults.BadRequest("Can't send empty payload"); }
            var book = books.Get(id);
            if (book == default) { return TypedResults.BadRequest("Id not found"); }

            book = books.Update(id, updatePayload);

            return TypedResults.Created(book.ToString());

        }

        public static IResult DeleteBook(IBookRepo books, int id)
        {
            var book = books.Remove(id);
            if (book == null) { return TypedResults.BadRequest($"No book was found with id: {id}"); }
            return TypedResults.Ok(book);
        }
    }
}
