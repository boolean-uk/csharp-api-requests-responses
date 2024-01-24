using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("books");
            studentGroup.MapGet("/", GetAllBooks);
            studentGroup.MapGet("/{id}", GetBookById);
            studentGroup.MapPost("/", CreateBook);
            studentGroup.MapPut("/{id}", UpdateBookById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IRepository<Book> b)
        {
            return TypedResults.Ok(b.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateBook(IRepository<Book> r, [FromBody] CreateBook bookInfo)
        {
            if (bookInfo == null) return TypedResults.BadRequest();
            return TypedResults.Created(" ", r.Create(bookInfo.ToBook(-1)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBookById(IRepository<Book> r, int id)
        {
            if (id == null) return TypedResults.BadRequest();
            Book res = r.GetByName(id.ToString());
            if (res == null) return TypedResults.NotFound();
            return TypedResults.Ok(res);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateBookById(IRepository<Book> r, int id, [FromBody] CreateBook bookInfo)
        {
            if (id == null) return TypedResults.BadRequest();
            Book result = r.Update(id.ToString(), bookInfo.ToBook(id));
            if (result == null) return TypedResults.NotFound();
            return TypedResults.Created(" ", result);
        }
    }
}
