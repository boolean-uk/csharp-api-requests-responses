using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, Language language)
        {
            //validate
            if (language == null)
            {

            }
            var newLanguage = new Language() { Name = language.Name };
            repository.AddLanguage(newLanguage);
            return TypedResults.Created($"/{newLanguage.Name}", newLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language language)
        {
            //validate
            if (language == null)
            {

            }
            return TypedResults.Ok(repository.UpdateLanguage(name, language));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string language)
        {
            var result = TypedResults.Ok(repository.GetLanguage(language));
            repository.DeleteLanguage(language);
            return result;
        }
    }
}
