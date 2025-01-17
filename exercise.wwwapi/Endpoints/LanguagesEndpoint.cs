
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguagesEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("language");

            languages.MapGet("/", GetAllLanguages);
            languages.MapPost("/", CreateLanguage);
            languages.MapGet("/{firstName}", GetSingleLanguage);
            languages.MapPut("/{firstName}", EditSingleLanguage);
            languages.MapDelete("/{firstName}", DeleteSingleLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAllLanguages(ILanguage repository)
        {
            return Results.Ok(repository.GetLanguages());

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetSingleLanguage(ILanguage repository, string name)
        {
            return Results.Ok(repository.GetLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateLanguage(ILanguage repository, Language model)
        {
            Language language = new Language(model.name)
            {
                name = model.name 
            };
            repository.CreateLanguage(language);
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> EditSingleLanguage(ILanguage repository, Language updatedLanguage, string name)
        {
            Language language = repository.GetLanguage(name);
            language.name = updatedLanguage.name;
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteSingleLanguage(ILanguage repository, string name)
        {
            try
            {
                Language language = repository.GetLanguage(name);
                if (repository.DeleteLanguage(name) != null)
                {
                    return Results.Ok(language);
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
