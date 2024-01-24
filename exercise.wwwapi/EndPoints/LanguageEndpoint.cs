using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("language");

            languageGroup.MapGet("/", GetAllLanguages);
            languageGroup.MapGet("/{name}", GetALanguage);
            languageGroup.MapPost("/", CreateLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}/", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateLanguage(IRepository repository, Languages language)
        {
            Languages newLanguage = repository.AddLanguage(language);
            return TypedResults.Created($"https://localhost:7206/students/{newLanguage.name}", newLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetALanguage(IRepository repository, string name)
        {
            Languages test = repository.GetALanguage(name);
            if (test == null)
            {
                return Results.NotFound($"Id: {name} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguage());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Languages language)
        {
            Languages test = repository.UpdateALanguage(name, language);
            if (test == null)
            {
                return Results.NotFound($"Id: {name} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            Languages test = repository.GetALanguage(name);
            return test == null ? Results.NotFound($"Id: {name} not found!") : TypedResults.Ok(repository.DeleteALanguage(name));
        }
    }
}
