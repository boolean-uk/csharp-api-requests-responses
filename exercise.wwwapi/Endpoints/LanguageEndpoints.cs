using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndPoints(this WebApplication app)
        {
            var languages = app.MapGroup("language");
            languages.MapGet("/", GetLanguages);
            languages.MapPost("/", CreateLanguage);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(ILanguageRepository repo, string name)
        {
            if (repo.DeleteLanguage(name))
                return TypedResults.Ok(true);
            return TypedResults.NotFound(false);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repo, string name)
        {
            var stud = repo.GetLanguage(name);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repo, string name, LanguageView dto)
        {
            var stud = repo.UpdateLanguage(name, dto);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateLanguage(ILanguageRepository repo, LanguageView dto)
        {
            var stud = repo.AddLanguage(dto);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repo)
        {
            return TypedResults.Ok(repo.GetLanguages());
        }
    }
}
