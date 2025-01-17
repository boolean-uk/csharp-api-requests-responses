namespace exercise.wwwapi.Endpoints;

using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

public static class LanguageEndpoint
{
    public static void ConfigureLanguageEndpoint(this WebApplication app)
    {
        var languages = app.MapGroup("languages");
        languages.MapGet("/", GetLanguages);
        languages.MapPost("/", CreateLanguage);
        languages.MapGet("/{name}", GetLanguage);
        languages.MapPut("/update/{name}", UpdateLanguage);
        languages.MapDelete("/{name}", DeleteLanguage);
    }

    public static async Task<IResult> GetLanguages(IRepository<Language, Language> repository)
    {
        return Results.Ok(repository.GetAll());
    }

    public static async Task<IResult> CreateLanguage(
        IRepository<Language, Language> repo,
        Language language
    )
    {
        //TODO: add good string
        // All fields required, so no LanguagePost
        return Results.Created($"{language.name}", repo.Create(language));
    }

    public static async Task<IResult> GetLanguage(IRepository<Language, Language> repo, string name)
    {
        return Results.Ok(repo.Get(l => l.name == name));
    }

    public static async Task<IResult> UpdateLanguage(
        IRepository<Language, Language> repo,
        string name,
        Language updated
    )
    {
        return Results.Created($"{updated.name}", repo.Update(l => l.name == name, updated));
    }

    public static async Task<IResult> DeleteLanguage(
        IRepository<Language, Language> repo,
        string name
    )
    {
        return Results.Ok(repo.Delete(l => l.name == name));
    }
}
