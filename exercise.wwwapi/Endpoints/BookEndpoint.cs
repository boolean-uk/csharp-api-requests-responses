
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapPost("/", CreateBook);
            bookGroup.MapGet("/", AllBooks);
            bookGroup.MapGet("/{id}", Book);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        private static async Task<IResult> CreateBook(IRepository<Book> repository, BookBody bookBody)
        {
            Book book = new Book()
            {
                Id = -1,
                NumPages = bookBody.NumPages,
                Title = bookBody.Title,
                Author = bookBody.Author,
                Genre = bookBody.Genre

            };
            repository.Add(book);
            return TypedResults.Created(book.Id.ToString(), book);
        }
        private static async Task<IResult> AllBooks(IRepository<Book> repository)
        {
            return TypedResults.Ok(repository.Get());
        }
        private static async Task<IResult> Book(IRepository<Book> repository, int id)
        {
            Book book = repository.GetById(id);

            return TypedResults.Ok(book);
        }
        private static async Task<IResult> UpdateBook(IRepository<Book> repository, int id, BookBody bookBody)
        {
            Book temp = new Book() 
            { 
                Id = id,
                NumPages = bookBody.NumPages,
                Title = bookBody.Title,
                Author = bookBody.Author,
                Genre = bookBody.Genre

            };
            Book book = (Book)repository.Update(id, temp);
            return TypedResults.Ok(book);
        }
        private static async Task<IResult> DeleteBook(IRepository<Book> repository, int id)
        {
            Book book = repository.GetById(id);
            repository.Delete(id);
            return TypedResults.Ok(book);
        }
    }
}
