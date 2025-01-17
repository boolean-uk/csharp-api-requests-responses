using System.Xml.Linq;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
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
            language.MapPut("/{name}", UpdateLanguage);
            language.MapPost("/", AddLanguage);
            language.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            var languages = repository.GetLanguages();
            return Results.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            var language = repository.GetLanguage(name);
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, LanguagePost model)
        {
            Language language = new Language(model.Name);
            repository.AddLanguage(language);

            return Results.Created("https://localhost:7068/languages", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            try
            {
                var model = repository.GetLanguage(name);
                if (repository.DeleteLanguage(name)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Name = model.name});
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, LanguagePut model)
        {
            var target = repository.GetLanguage(name);
            if (target == null) return TypedResults.NotFound();
            if (model.Name != null) target.name = model.Name;
            return TypedResults.Ok(target);
        }

    }
}
