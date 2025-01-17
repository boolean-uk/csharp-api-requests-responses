using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var language = app.MapGroup("language");

            language.MapGet("/", GetAll);
            language.MapGet("/{name}", GetOne);
            language.MapPost("/", AddLanguage);
            language.MapDelete("/{name}", DeleteLanguage);
            language.MapPut("/{name}", UpdateLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Language> repository)
        {
            var languages = repository.GetAll();
            return Results.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOne(IRepository<Language> repository, string name)
        {
            var language = repository.GetOne(name);
            return Results.Ok(language);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository<Language> repository, LanguagePost model)
        {
            Language language = new Language(model.name);

            repository.Add(language);

            return Results.Created($"https://localhost:7010/pets/{language.name}", language);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepository<Language> repository, string name)
        {
            try
            {
                var model = repository.GetOne(name);
                if (repository.Delete(name)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", name = model.name});
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateLanguage(IRepository<Language> repository, string name, LanguagePut model)
        {
            try
            {
                var target = repository.GetOne(name);
                if (target == null) return Results.NotFound();
                if (model.Name != null) target.name = model.Name;
                return Results.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

    }
}
