using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

public static class LanguageEndpoint
{
    public static void ConfigureLanguageEndpoint(this WebApplication app)
    {
        var languageGroup = app.MapGroup("languages");

        languageGroup.MapPost("/create/", CreateLanguage);
        languageGroup.MapGet("/", GetLanguages);
        languageGroup.MapGet("/{name}", GetLanguage);
        languageGroup.MapPut("/{name}", UpdateLanguage);
        languageGroup.MapDelete("/{name}", DeleteLanguage);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    public static async Task<IResult> CreateLanguage(ILanguageRepository repository, Language language)
    {
        return TypedResults.Created($"/{language.Name}", repository.AddLanguage(language));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetLanguages(ILanguageRepository repository)
    {
        return TypedResults.Ok(repository.GetLanguages());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
    {
        var language = repository.GetLanguages().FirstOrDefault(x => x.Name == name);

        if (language == null)
        {
            return Results.NotFound($"Language: {name} not found!");
        }

        return TypedResults.Ok(language);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, Language language)
    {
        var toEdit = repository.GetLanguages().FirstOrDefault(x => x.Name == name);

        if (toEdit == null)
        {
            return Results.NotFound($"Language: {name} not found!");
        }

        toEdit.Name = language.Name;
        return TypedResults.Ok(toEdit);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
    {
        var Deleted = repository.DeleteLanguage(name);

        if (Deleted == null)
        {
            return Results.NotFound($"Language: {name} not found!");
        }

        return TypedResults.Ok(Deleted);
    }
}
