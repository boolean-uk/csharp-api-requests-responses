using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Threading.Tasks;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapGet("/", GetAllLanguages);
            languageGroup.MapPost("/", CreateLanguage);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
        }

        public static IResult GetAllLanguages(ILanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetAllLanguages());
        }

        
        public static IResult GetLanguage(ILanguageRepository languages, string name)
        {
            try
            {
                Language lg = languages.GetLanguage(name);
                if (lg == null)
                {
                    return Results.NotFound($"Language with name {name} not found.");
                }
                return Results.Ok(lg);

            } catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
        }

        public static IResult DeleteLanguage(ILanguageRepository languages, string name)
        {
            try
            {
                Language lg = languages.DeleteLanguage(name);
                if (lg == null)
                {
                    return Results.NotFound($"Language with name {name} not found.");
                }
                return Results.Ok(lg);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }

        public static IResult CreateLanguage(ILanguageRepository languages, LanguagePostPayload newLanguageData)
        {
            if(newLanguageData.name.Length == 0) 
            {
                return Results.NotFound($"Language needs a name to be created!");
            }

            Language lg = languages.AddLanguage(newLanguageData.name);
            return TypedResults.Created($"/languages{lg.name}", lg);

        }

        public static IResult UpdateLanguage(ILanguageRepository languages, string name, LanguageUpdatePayload newLanguageData)
        {

            try
            {
                Language? lg = languages.UpdateLanguage(name, newLanguageData);
                
                if (lg == null)
                {
                    return Results.NotFound($"Language with name {name} not found.");
                }
                // return Results.Ok(st);
                name = lg.name;
                return TypedResults.Created($"/languages{lg}", lg);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }
        
    }
}
