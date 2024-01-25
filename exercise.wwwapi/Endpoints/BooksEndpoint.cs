using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoint
    {
        public static void ConfigureBooksEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapGet("/", GetAllBooks);
            bookGroup.MapGet("/{id}", GetSpecificBook);
            bookGroup.MapPost("/", PostNewBook);
            bookGroup.MapPut("/{id}", PutBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IRepository repository)
        {

            return TypedResults.Ok(repository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetSpecificBook(IRepository repository, int id)
        {
            Book? book = repository.GetSpecificBook(id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound($"Could not find book with ID {id}");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> PostNewBook(IRepository repository, string Title, int numPages, string author, string genre) 
        {
            BookDraft tempBook = new BookDraft() { Title = Title, NumPages = numPages, Author = author, Genre = genre };
            Book? book = repository.AddNewBook(tempBook);
            if (book != null)
            {
                return TypedResults.Created($"/books/{book.Id}", book);
            }
            else
            {
                return TypedResults.BadRequest("Could not post the book.");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> PutBook(IRepository repository, int id, string title, int numPages, string author, string genre)
        {
            BookDraft tempBook = new BookDraft() { Title = title, NumPages = numPages, Author = author, Genre = genre };
            Book? book = repository.UpdateBook(id, tempBook);
            if (book != null)
            {
                return TypedResults.Created($"/books/{book.Id}", book);
            }
            else
            {
                return TypedResults.NotFound($"Could not find a book with id {id}");
            }
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            Book? book = repository.RemoveBook(id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound($"Could not find a book with id {id}");
            }
        }
    }
}
