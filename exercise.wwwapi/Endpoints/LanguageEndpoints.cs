using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Xml.Linq;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapGet("/GetAllLanguages", GetAllLanguages);
            languageGroup.MapGet("/GetLanguage", GetLanguage);
            languageGroup.MapPost("/CreateLanguage", CreateLanguage);
            languageGroup.MapPut("/UpdateLanguage{name}", UpdateLanguage);
            languageGroup.MapDelete("/RemoveLanguage{name}", RemoveLanguage);
        }
        public static IResult GetAllLanguages(ILanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetAllLanguages());
        }
        public static IResult GetLanguage(ILanguageRepository languages, string name)
        {
            return TypedResults.Ok(languages.GetLanguage(name));
        }
        public static IResult CreateLanguage(ILanguageRepository languages, LanguagePostPayload newLanguageData)
        {
            try
            {
                Language language = languages.AddLanguage(newLanguageData.name);
                if(newLanguageData.name == null)
                {
                    return TypedResults.NotFound($"You must enter a name.");
                }
                return TypedResults.Created($"/language{language.Name}", language);
            }
            catch (Exception e)
            {
                return TypedResults.NotFound(e.Message);
            }
            
        }
        public static IResult UpdateLanguage(ILanguageRepository languages, string name, LanguageUpdatePayload updateData)
        {
            try
            {
                Language? language = languages.UpdateLanguage(name, updateData);
                if (language == null)
                {
                    return TypedResults.NotFound($"Language with {name} not found.");
                }
                return TypedResults.Created($"/languages{language.Name}", language);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e.Message);
            }
        }
        public static IResult RemoveLanguage(ILanguageRepository languages, string name)
        {
            return TypedResults.Ok(languages.RemoveLanguage(name));
        }
    }
}
