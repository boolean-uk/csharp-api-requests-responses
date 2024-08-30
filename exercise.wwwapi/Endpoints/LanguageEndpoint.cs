using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

public static class LanguageEndpoint
{
    public static void ConfigureLanguageEndpoint(this WebApplication app)
    {
        var lang = app.MapGroup("lang");
        lang.MapGet("/", GetAllLanguages);
        lang.MapPost("/", CreateNewLanguage);
        lang.MapGet("/{name}", GetLanguage);
        lang.MapPut("/{name}", UpdateLanguage);
        lang.MapDelete("/{name}", DeleteLanguage);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    public static IResult GetAllLanguages(IRepository<Language, string> collection)
    {
        return TypedResults.Ok(collection.GetAll());
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult GetLanguage(IRepository<Language, string> collection, string name)
    {
        var l = collection.GetAll().FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        if (l is null) return TypedResults.NotFound();
        return TypedResults.Ok(l);
    }
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    public static IResult CreateNewLanguage(IRepository<Language, string> collection, Language language)
    {
        var l = collection.Create(language);
        return TypedResults.Created($"/stud{l.Name}", l);
    }
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult UpdateLanguage(IRepository<Language, string> collection, string firstName, Language language)
    {
        var l = collection.GetAll().FirstOrDefault(x => x.Name == firstName);
        if (l is null) return TypedResults.NotFound();
        l.Name = language.Name;
        return TypedResults.Created($"/stud{l.Name}", l);
    }
    
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult DeleteLanguage(IRepository<Language, string> collection, string name)
    {
        var l = collection.GetAll().FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        if (l is null) return TypedResults.NotFound();
        
        return TypedResults.Ok(collection.Delete(l));
    }
}