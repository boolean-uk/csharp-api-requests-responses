using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguagesEndpoint(this WebApplication app)
        {
            var languagesGroup = app.MapGroup("languages");

            //carGroup.MapGet("/", GetCars);
            languagesGroup.MapGet("/", GetLanguages);
            languagesGroup.MapGet("/{name}", GetOneLanguage);
            languagesGroup.MapPut("/{name}", PutLanguage);
            languagesGroup.MapPost("/", PostLanguage);
            languagesGroup.MapDelete("/{name}", DeleteLanguage);
        }
        [ProducesResponseType(StatusCodes.Status200OK)] //status code 200 : Success
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages()); //Returns all languages in the List<>
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOneLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetOneLanguage(name));
        }
        [ProducesResponseType(StatusCodes.Status201Created)] //status code 201 : Created
        public static async Task<IResult> PutLanguage(IRepository repository, string name, Language language)
        {
            return TypedResults.Ok(repository.UpdateLanguage(name,language));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PostLanguage(IRepository repository, Language language)
        {
            return TypedResults.Ok(repository.AddLanguage(language));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.DeleteLanguage(name));
        }
    }
}