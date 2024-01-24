using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndPoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var dataGroup = app.MapGroup("book");

            dataGroup.MapPost("/create", CreateBook);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(IRepository repository, Book book)
        {
            return TypedResults.Ok(repository.getStudentCollections());
        }
    }
}
