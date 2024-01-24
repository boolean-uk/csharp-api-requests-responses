using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("books");

            studentGroup.MapGet("", GetBook);
            studentGroup.MapPost("", CreateBook);
            studentGroup.MapGet("/{id}", FindBook);
            studentGroup.MapPut("/{id}", UpdateBook);
            studentGroup.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IRepository repository)
        {
            if (repository.GetAllBooks().Count() == 0) return TypedResults.NotFound();
            return TypedResults.Ok(repository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateBook(IRepository repository, BookPut book)
        {         
            if ( !( book.Title.Any() & book.Author.Any() & 
                book.Genre.Any() & book.numPages != 0 ) ) return TypedResults.BadRequest();
            Book newBook = repository.CreateBook(book);
            return TypedResults.Created($"https://localhost:7068/students/{newBook.Id}", newBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> FindBook(IRepository repository, int Id)
        {
            Book book = repository.FindBook(Id);
            return book == null ? TypedResults.NotFound() : TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateBook(IRepository repository, int Id, BookPut book)
        {
            Book newBook = repository.FindBook(Id);
            if (!(book.Title.Any() & book.Author.Any() &
                book.Genre.Any() & book.numPages != 0)) return TypedResults.BadRequest();
            if (newBook == null) return TypedResults.NotFound();
            newBook.Update(book);
            return TypedResults.Ok(newBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IRepository repository, int Id)
        {
            Book book = repository.FindBook(Id);
            if (book == null) return TypedResults.NotFound();
            repository.removeBook(Id);
            return TypedResults.Ok(book);
        }
    }
}
