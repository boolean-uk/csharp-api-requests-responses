using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("language");
            studentGroup.MapGet("/", GetAllLanguages);
            studentGroup.MapGet("/{name}", GetLanguageByName);
            studentGroup.MapPost("/", CreateLanguage);
            studentGroup.MapPut("/{name}", UpdateLanguageByName);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(ILanguageRepository r)
        {
            return TypedResults.Ok(r.GetAllStudents());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateLanguage(ILanguageRepository r, [FromBody] Language s)
        {
            if (s == null) return TypedResults.BadRequest();
            return TypedResults.Created(" ", r.CreateStudent(s));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguageByName(ILanguageRepository r, string name)
        {
            if (name == null) return TypedResults.BadRequest();
            Language res = r.GetStudent(name);
            if (res == null) return TypedResults.NotFound();
            return TypedResults.Ok(res);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateLanguageByName(ILanguageRepository r, string name, [FromBody] Language updateLanguage)
        {
            if (name == null) return TypedResults.BadRequest();
            Language result = r.UpdateStudent(name, updateLanguage);
            if (result == null) return TypedResults.NotFound();
            return TypedResults.Created(" ", result);
        }
    }
}
