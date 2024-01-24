using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("languages");

            studentGroup.MapGet("/", GetLanguages);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {


            return TypedResults.Ok(repository.GetLanguages());
        }

    }
}
