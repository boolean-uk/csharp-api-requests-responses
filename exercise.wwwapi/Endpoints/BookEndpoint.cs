using exercise.wwwapi.Models.DTO;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("books");

            languageGroup.MapGet("/", GetBooks); //get all
            languageGroup.MapGet("/{providedId}", GetABook); //get a 
            languageGroup.MapPost("/{providedBook}", AddBook); //add
            languageGroup.MapDelete("/{providedId}", DeleteBook); //delete
            languageGroup.MapPut("/{providedId}", UpdateBook); //update
        }

        //get all
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository<Book> bookxRepository)
        {
            var results = await bookxRepository.Get();
            Payload<IEnumerable<Book>> payload = new Payload<IEnumerable<Book>>();
            payload.data = results;
            return Results.Ok(payload);
        }


        //get a
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetABook(IRepository<Book> repository, int providedId)
        {
            var books = await repository.Get();
            if (books.Any(x => x.Id == providedId))
            {
                return Results.Ok(repository.GetById(providedId).Result);
            }
            else
            {
                return Results.NotFound("Book not found");
            }
        }


        //add
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddBook(IRepository<Book> repository, BookPost newbook)
        {
            var books = await repository.Get();

            if (books.Any(x => x.Title.Equals(newbook.Title, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest("Book with provided title already exists");
            }
            int id = books.Max(x => x.Id) + 1;
            var entity = new Book() { Id = id, Title = newbook.Title, numPages = newbook.numPages, author = newbook.author, genre = newbook.genre };
            await repository.Insert(entity);
            return TypedResults.Created($"/{entity}");
        }


        //delete
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteBook(IRepository<Book> repository, int providedId)
        {
            var books = await repository.Get();
            if (books.Any(x => x.Id == providedId))
            {
                var book = books.FirstOrDefault(x => x.Id == providedId);
                await repository.Delete(providedId);
                return Results.Ok("Book deleted: " + book.Title);
            }
            else
            {
                return Results.NotFound("Book not found");
            }
        }


        //update
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateBook(IRepository<Book> repository, int providedId, BookPut updateBook)
        {
            var books = await repository.Get();

            if (books.Any(x => x.Id == providedId))
            {
                var book = books.FirstOrDefault(x => x.Id == providedId);
                book.Title = updateBook.Title;
                book.numPages = updateBook.numPages;
                book.author = updateBook.author;
                book.genre = updateBook.genre;
                repository.Update(book);
                return TypedResults.Created($"/{book}");

            }
            return Results.BadRequest("Book can't be updated");
        }


    }
}
