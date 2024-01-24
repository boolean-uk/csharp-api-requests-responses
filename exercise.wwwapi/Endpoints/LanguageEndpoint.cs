using exercise.wwwapi.Models;
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
            studentGroup.MapGet("/{language}", GetLanguage);
            studentGroup.MapPost("/", CreateLanguage);
            studentGroup.MapPut("/{language}", UpdateLanguage);
            studentGroup.MapDelete("/{language}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateLanguage(IRepository repository, Language language)
        {
            return TypedResults.Created("", repository.CreateLanguage(language));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string language, string newLanguage)
        {
            return TypedResults.Ok(repository.Updatelanguage(language, newLanguage));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string language)
        {
            return TypedResults.Ok(repository.DeleteLanguage(language));
        }
    }
}