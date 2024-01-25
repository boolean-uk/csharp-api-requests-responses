using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndPoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
        {
            Language language = repository.GetLanguage(name);
            if (language != null)
            {
                return TypedResults.Ok(language);
            }
            else
            {
                return TypedResults.NotFound($"Language with that name does not exist.");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, LanguagePost model)
        {
            if (model == null)
            {

            }
            var newLanguage = new Language(model.Name);
            repository.AddLanguage(newLanguage);
            return TypedResults.Created($"/{newLanguage.Name}", newLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, LanguagePut model)
        {
            return TypedResults.Ok(repository.UpdateLanguage(name, model));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            Language deleteThis = repository.DeleteLanguage(name);
            if (deleteThis != null)
            {
                return TypedResults.Ok(deleteThis);
            }
            else
            {
                return TypedResults.NotFound($"Language with that name does not exist.");
            }
        }
    }
}
