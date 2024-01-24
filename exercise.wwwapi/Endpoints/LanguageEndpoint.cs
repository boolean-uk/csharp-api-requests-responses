using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapPost("/", CreateLanguage);           
            languageGroup.MapGet("/", GetAllLanguages);            
            languageGroup.MapGet("/{name}", GetLanguage);            
            languageGroup.MapPut("/{name}", UpdateLanguage);            
            languageGroup.MapDelete("/{name}", DeleteLanguage);
            
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateLanguage(ILangageRepository repository, Language language)
        {
            Language createdLanguge = repository.CreateLanguage(language);
            return TypedResults.Created("languages/", createdLanguge);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(ILangageRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(ILangageRepository repository, string name)
        {            
            Language language = repository.GetLanguage(name);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(ILangageRepository repository, string name, Language language)
        {
            Language retrievedLanguage = repository.Update(name, language);
            return TypedResults.Created("languages/{name}", retrievedLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(ILangageRepository repository, string name)
        {
            return TypedResults.Ok(repository.Delete(name));
        }
    }
}
