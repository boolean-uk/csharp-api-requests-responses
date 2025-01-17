using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi
{
    public static class BooksEndpoint
    {
        public static void ConfigureBooksEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetAll);
            books.MapPost("/", Add);
            books.MapDelete("/{id}", Delete);
            books.MapPut("/{id}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(BooksRepository booksRepository)
        {
            var books = booksRepository.GetAll();
            return Results.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Add(BooksRepository booksRepository, string title, int numPages, string author, string genre)
        {
            int newId = booksRepository.GetAll().Max(b => b.Id) + 1;

            Book book = new Book()
            {
                Id = newId,
                Title = title,
                NumPages = numPages,
                Author = author,
                Genre = genre
            };

            booksRepository.Add(book);

            return Results.Created($"https://localhost:7010/books/{book.Id}", book);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(BooksRepository booksRepository, int id)
        {
            var book = booksRepository.Get(id);
            if (book != null && booksRepository.Delete(id))
            {
                return Results.Ok(new { Status = "Deleted", Book = book });
            }
            return Results.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(BooksRepository booksRepository, int id, string newTitle, int newNumPages, string newAuthor, string newGenre)
        {
            var book = booksRepository.Get(id);
            if (book == null) return Results.NotFound();

            var updatedBook = booksRepository.Update(id, newTitle, newNumPages, newAuthor, newGenre);
            if (updatedBook != null)
            {
                return Results.Ok(updatedBook);
            }

            return Results.BadRequest();
        }
    }
}
