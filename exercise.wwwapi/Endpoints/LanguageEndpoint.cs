using System;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.View;

namespace exercise.wwwapi.Endpoints;

public static class LanguageEndpoint
{
    public static void ConfigureLanguageEndpoint(this WebApplication app)
    {
        var students = app.MapGroup("languages");

        students.MapGet("/", GetLanguages);
        students.MapPost("/", AddLanguage);
        students.MapGet("/{name}", GetLanguage);
        students.MapDelete("/{name}", DeleteLanguage);
        students.MapPut("/{name}", UpdateLanguage);
    }

    public static async Task<IResult> GetLanguages(ILanguageRepository repository)
    {
        var languages = repository.GetLanguages();
        return Results.Ok(languages);
    }

    public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
    {
        var language = repository.GetLanguage(name);
        if (language == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(language);
    }

    public static async Task<IResult> AddLanguage(ILanguageRepository repository, LanguagePost language)
    {
        var newLanguage = repository.AddLanguage(new Language() { name = language.Name });
        return Results.Created($"/languages/{newLanguage.name}", newLanguage);
    }

    public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, LanguagePut language)
    {
        var updatedLanguage = repository.UpdateLanguage(name, new Language() { name = language.Name });
        if (updatedLanguage == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(updatedLanguage);
    }

    public static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
    {
        var result = repository.DeleteLanguage(name);
        if (!result)
        {
            return Results.NotFound();
        }
        return Results.NoContent();
    }
}
