using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {

        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetLanguages);

            languages.MapGet("/{name}", GetLanguage);



            languages.MapPost("/", AddLanguages);

            languages.MapDelete("/{name}", DeleteLanguage);
            languages.MapPut("/{name}", UpdateLanguage);


        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> UpdateLanguage(IRepository<Language> languagerepository, string name, string newname)
        {
            var language = languagerepository.UpdateEntity(name, newname);
            return Results.Ok(language);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetLanguage(IRepository<Language> languagerepository, string name)
        {
            var language = languagerepository.GetEntity(name);
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteLanguage(IRepository<Language> languagerepository, string name)
        {
            var deleted = languagerepository.DeleteEntity(name);

            return Results.Ok(deleted);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddLanguages(IRepository<Language> languagerepository, Language language)
        {
            languagerepository.AddEntity(language);

            return Results.Ok(language);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetLanguages(IRepository<Language> languagerepository)
        {
            var languages = languagerepository.GetCollection();
            return Results.Ok(languages);

        }
    }
}
