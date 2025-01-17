using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var pets = app.MapGroup("books");

            pets.MapGet("/gettAll", GetAllBooks);
            pets.MapGet("/get{id}", GetBook);
            pets.MapPost("/add", AddBook);
            pets.MapDelete("/delete{Firstname}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            var student = repository.GetBooks().FirstOrDefault(x => x.Id == id);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IRepository repository)
        {
            var students = repository.GetBooks();
            return Results.Ok(students);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddBook(IRepository repository, Book model)
        {
            Book book = new Book(
            
                 model.Title,
                 model.Author,
                 model.Genre,
                 model.NumberOfPages)
            ;
            repository.AddBook(book);

            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            try
            {
                var model = repository.GetBook(id);
                if (repository.DeleteBook(id)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Title = model.Title, Author = model.Author, Genre = model.Genre, NumberOfPages = model.NumberOfPages });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
