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
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, string newLanguage) 
        {
            var languageToAdd = new Language(newLanguage); 
            return TypedResults.Ok(repository.AddLanguage(languageToAdd));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name) 
        {
            var language = repository.GetLanguage(name);
            return TypedResults.Ok(repository.AddLanguage(language));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, string newName) 
        {
            var language = repository.UpdateLanguage(name, newName);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name) 
        {
            var language = repository.DeleteLanguage(name);
            return TypedResults.Ok(language);
        }

        
    }
}
