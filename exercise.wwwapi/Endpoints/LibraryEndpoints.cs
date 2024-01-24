
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LibraryEndpoints
    {
        public static void ConfigureLibraryEndpoints(this WebApplication app)
        {
            var libraryGroup = app.MapGroup("books");

            libraryGroup.MapGet("/", GetBooks);
            libraryGroup.MapGet("/{id}", GetBook);
            libraryGroup.MapPost("/", AddBook);
            libraryGroup.MapPut("/{id}", UpdateBook);
            libraryGroup.MapDelete("/{id}", DeleteBook);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(Library library)
        {
            return TypedResults.Ok(library.AllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(Library library, int id)
        {
            return TypedResults.Ok(library.GetBook(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> AddBook(Library library, BookPost book)
        {
            var newBook = new Book() 
            {
                Id = library.AllBooks().Count() + 1,
                Title = book.Title,
                Author = book.Author,
                NumPages = book.NumPages,
                Genre = book.Genre
            };
            library.AddBook(newBook);
            return TypedResults.Created("/", newBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(Library library, BookPut book, int id)
        {
            return TypedResults.Ok(library.UpdateBook(id, book));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> DeleteBook(Library library, int id)
        {
            return TypedResults.Ok(library.DeleteBook(id));
        }
    }
}
