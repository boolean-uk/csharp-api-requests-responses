
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpionts
{
    public static class BooksEndpoint
    {
        public static void ConfigureBooksEndpoint(this WebApplication application)
        {
            var booksGroupe = application.MapGroup("Books");
            booksGroupe.MapGet("/", GetAllBooks);
            booksGroupe.MapGet("/{id}", GetABook);
            booksGroupe.MapPost("/", PostABook);
            booksGroupe.MapPut("/{id}", UppdateBook);
            booksGroupe.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetABook(IBookRepository repository, string Title)
        {
            return TypedResults.Ok(repository.GetABook(Title));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult PostABook(IBookRepository repository, string title, int numPages, string author, string genre)
        {
            return TypedResults.Ok(repository.PostABook(title, numPages, author, genre));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UppdateBook(IBookRepository repository, string title, string newtitle, int? newnumPages, string newauthor, string newgenre)
        {
            return TypedResults.Ok(repository.UppdateBook(title, newtitle, newnumPages, newauthor, newgenre));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IBookRepository repository, string title)
        {
            return TypedResults.Ok(repository.DeleteBook(title));
        }
    }
}
