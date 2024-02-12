using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var LanguageGroup = app.MapGroup("languages");

            LanguageGroup.MapPost("/add", AddLanguage);
            LanguageGroup.MapGet("/all", GetAllLanguages);
            LanguageGroup.MapGet("/get", GetLanguage);
            LanguageGroup.MapPut("/update", UpdateLanguage);
            LanguageGroup.MapDelete("/delete", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, string Name)
        {
            var newLanguage = new Language() { Name = Name };
            return TypedResults.Created($"New language: ", newLanguage);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetAllLanguages());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string Name)
        {
            return TypedResults.Ok(repository.GetLanguage(Name));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string Name, Language language)
        {
            return TypedResults.Ok(repository.UpdateLanguage(Name, language));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string Name)
        {
            return TypedResults.Ok(repository.DeleteLanguage(Name));
        }
    }
}
