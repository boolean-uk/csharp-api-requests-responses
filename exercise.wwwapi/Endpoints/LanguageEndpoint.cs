using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var language = app.MapGroup("language");

            language.MapGet("/", GetLanguages);
            language.MapGet("/{name}", GetLanguage);
            language.MapPost("/", AddLanguage);
            language.MapDelete("/{name}", DeleteLanguage);
            language.MapPut("/{name}", UpdateLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            var language = repository.GetLanguages();
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repository, [FromRoute] string name)
        {
            var language = repository.GetLanguage(name);
            if (language == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, Language model)
        {
            Language language = new Language()
            {
                Name = model.Name,
                
            };
            repository.AddLanguage(language);

            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteLanguage(ILanguageRepository repository, [FromRoute] string name)
        {
            try
            {
                var model = repository.GetLanguage(name);
                if (repository.DeleteLanguage(name))
                {
                    return Results.Ok(model);
                }
                else
                {
                    return TypedResults.NotFound();
                }
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> UpdateLanguage(ILanguageRepository repository, [FromRoute] string name, Language model)
        {
            var language = new Language()
            {
                Name = model.Name,
            };
            var updatedStudent = repository.UpdateLanguage(name, language);
            return Results.Ok(updatedStudent);
        }
    }
}
