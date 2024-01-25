
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

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapGet("/{name}", GetLanguageByName);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async static Task<IResult> AddLanguage(IRepository repository, Language language)
        {
            var newLanguage = new Language()
            {
                name = language.name
            };
            {
                repository.AddLanguage(newLanguage);
                return TypedResults.Created($"{newLanguage.name}");
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> GetLanguageByName(IRepository repository, string name)
        {
            var result = repository.GetLanguageByName(name);
            if (result != null)
            {
                return TypedResults.Ok(result);
            }
            else return TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> UpdateLanguage(IRepository repository, string name, LanguagePut languagePut)
        {
            return TypedResults.Ok(repository.UpdateLanguage(name, languagePut));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.DeleteLanguage(name));
        }
    }

}
