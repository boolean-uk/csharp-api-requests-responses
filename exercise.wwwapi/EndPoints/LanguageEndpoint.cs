using System;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints;

public static class LanguageEndpoint 
{
    public static void ConfigureLanguageEndpoint(this WebApplication app)
    {
        var language = app.MapGroup("language");

        language.MapGet("/", GetAllLanguages);
        language.MapGet("/{name}", GetLanguage);
        language.MapPost("/{name}", CreateLanguage);
        language.MapPatch("/{name}", UpdateLanguage);
        language.MapDelete("/{name}", DeleteLanguage);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetAllLanguages(ILanguageRepository repo)
    {
        return TypedResults.Ok(repo.GetLanguages());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetLanguage(ILanguageRepository repo, string name)
    {
        Language result = repo.GetLanguage(name);

        if (result == null)
        {
            return TypedResults.NotFound(name);
        }

        return TypedResults.Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public static async Task<IResult> CreateLanguage(ILanguageRepository repo, string name)
    {
        Language result = repo.AddLanguage(name);
        if (result == null)
        {
            return TypedResults.Conflict($"Language already exists: {name}");
        }

        return TypedResults.Created(name);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> UpdateLanguage(ILanguageRepository repo, string currentName, string newName)
    {
        Language result = repo.UpdateLanguage(currentName, newName);

        if (result == null)
        {
            return TypedResults.NotFound(currentName);
        }

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> DeleteLanguage(ILanguageRepository repo, string name)
    {
        Language result = repo.DeleteLanguage(name);

        if (result == null)
        {
            return TypedResults.NotFound($"Languge was not found: {name}");
        }

        return TypedResults.Ok(result);
    }

}
