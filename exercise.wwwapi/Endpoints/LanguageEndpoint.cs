using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetLanguages);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPost("/", AddLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            var languages = repository.GetLanguages();
            return Results.Ok(languages);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
        {
            var language = repository.GetLanguage(name);
            if (language == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(language);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, Language language)
        {
            Language newLanguage = new Language()
            {
                name = language.name,
            };

            repository.AddLanguage(newLanguage);
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, Language language)
        {
            try
            {
                var existingLanguage = repository.GetLanguage(name);
                if (existingLanguage == null)
                {
                    return Results.NotFound();
                }

                var updatedLanguage = repository.UpdateLanguage(name, language);
                if (updatedLanguage == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(new
                {
                    when = DateTime.Now,
                    status = "Updated",
                    oldLanguage = existingLanguage,
                    updatedLanguage = updatedLanguage
                });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            try
            {
                var languageToDelete = repository.GetLanguage(name);
                if (repository.Delete(name)) return Results.Ok(new { when = DateTime.Now, status = "Deleted", Name = languageToDelete.name });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
