using System;
using exercise.wwwapi.Extensions;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndPoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
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
            var l = repo.DeleteLanguage(name);
            if (l != null)
                return TypedResults.Ok(l);
            return TypedResults.NotFound(false);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repo, string name)
        {
            var langu = repo.GetLanguage(name);
            if (langu != null)
                return TypedResults.Ok(langu);
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateLanguage(HttpContext context, ILanguageRepository repo, string name, LanguageView dto)
        {
            var langu = repo.UpdateLanguage(name, dto);
            if (langu != null)
                return TypedResults.Created(context.Get_endpointUrl(langu.name), langu);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateLanguage(HttpContext context, ILanguageRepository repo, LanguageView dto)
        {
            var langu = repo.AddLanguage(dto);
            if (langu != null)
                return TypedResults.Created(context.Get_endpointUrl(langu.name),langu);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repo)
        {
            return TypedResults.Ok(repo.GetLanguages());
        }
    }
}
