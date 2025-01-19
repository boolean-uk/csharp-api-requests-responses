
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var book = app.MapGroup("books");

            book.MapGet("/", GetAll);
            book.MapPost("/{title}", GetBook);
            book.MapPost("/", AddBook);
            book.MapDelete("/{title}", DeleteBook);
            book.MapPut("/{id}", UpdateBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository3 repository)
        {
            var students = repository.GetAllBooks();
            return Results.Ok(students);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IRepository3 repository, int id)
        {

            var book = repository.GetBook(id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddBook(IRepository3 repository, Book book)
        {

            if (book != null)
            {
                repository.AddBook(book);
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IRepository3 repository, string title)
        {

            var book = repository.DeleteBook(title);
            if (book != null)

            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateBook(IRepository3 repository,int id, string updateTitle, int updateNumPages, string updateAuthor, string updateGenre)
        {

            var book = repository.UpdateBook(id, updateTitle, updateNumPages, updateAuthor, updateGenre);

            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }



    }
}
