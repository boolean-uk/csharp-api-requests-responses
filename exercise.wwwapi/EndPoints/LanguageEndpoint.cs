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

            languageGroup.MapPost("/Create a language/", CreateLanguage);
            languageGroup.MapGet("/Get a language {language}/", GetALanguage);
            languageGroup.MapGet("/Get all language/", GetAllLanguages);
            languageGroup.MapPut("/Update a language {language}/", UpdateLanguage);
            languageGroup.MapDelete("/Delete a language {language}/", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateLanguage(IRepository repository, Language language)
        {
            Language newLanguage = repository.AddLanguage(language);
            return TypedResults.Created($"https://localhost:7206/students/{newLanguage.name}", newLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetALanguage(IRepository repository, string name)
        {
            Language test = repository.GetALanguage(name);
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
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language language)
        {
            Language test = repository.UpdateALanguage(name, language);
            if (test == null)
            {
                return Results.NotFound($"Id: {name} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            Language test = repository.GetALanguage(name);
            return test == null ? Results.NotFound($"Id: {name} not found!") : TypedResults.Ok(repository.DeleteALanguage(name));
        }
    }
}
