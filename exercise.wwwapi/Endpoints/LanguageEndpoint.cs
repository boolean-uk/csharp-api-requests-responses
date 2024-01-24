using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class languageEndpoint
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/", getAll);
            languages.MapGet("/singlelanguage/", getAlanguage);
            languages.MapPost("/", Add);
            languages.MapPut("/{firstname}", updatelanguage);
            languages.MapDelete("/{firstname}", deletelanguage);
        }
        public static IResult getAll(ILanguageRepository languages) {
            return TypedResults.Ok(languages.getAll());    
        }
        public static IResult Add(ILanguageRepository languages, LanguagePostPayload newlanguageData)
        {
            Language language = languages.Add(newlanguageData.Language);
            return TypedResults.Created($"/languages{language.name}", language);
        } 
        public static IResult getAlanguage(ILanguageRepository languages, string name)
        {
            Language? language = languages.getALanguage(name);
            if (language == null)
            {
                return Results.NotFound($"language with firstname {name} not found.");
            }
            return TypedResults.Ok( language);
        }
        public static IResult updatelanguage(ILanguageRepository languages, string name, string newName)
        {
            try
            { 
                Language? item = languages.updateLanguage(name, newName);
                if (item == null)
                {
                    return Results.NotFound($"language with firstname {name} not found.");
                }
                return Results.Created($"/languages{item.name}",item);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static IResult deletelanguage(ILanguageRepository languages, string firstname)
        {
            try
            {
                Language? item = languages.deleteLanguage(firstname); 
                if (item == null)
                {
                    return Results.NotFound($"language with firstname {firstname} not found.");
                }
                return Results.Ok(item);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message); 
            }
        }
    }
}