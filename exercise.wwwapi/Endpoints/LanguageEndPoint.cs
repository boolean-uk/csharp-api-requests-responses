using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndPoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("language");

            languageGroup.MapPost("/create/{name}", CreateLanguage);
            languageGroup.MapGet("/getAll", GetLanguages);
            languageGroup.MapGet("/get/{name}", GetLanguage);
            languageGroup.MapPut("/update/{name}", UpdateLanguage);
            languageGroup.MapDelete("delete/{name}", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.createLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.getLanguageCollections());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.getLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, string newName)
        {
            return TypedResults.Ok(repository.updateLanguage(name, newName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.deleteLanguage(name));
        }
    }
}
