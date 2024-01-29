using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    //Endpoints for language
    public static class LanguageEndpoints
    {
        public static void configureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            
            //Get
            languageGroup.MapGet("getAll", GetLanguages);
            languageGroup.MapGet("getByName", GetLanguageByName);

            //Post
            languageGroup.MapPost("create", CreateNewLanguage);

            //Put
            languageGroup.MapPut("update", UpdateLanguage);

            //Delete
            languageGroup.MapDelete("remove", RemoveLanguage);
        }

        public static IResult GetLanguages(IlanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetLanguages());
        }

        public static IResult GetLanguageByName(IlanguageRepository languages, string name)
        {
            return TypedResults.Ok(languages.GetLanguageByName(name));
        }

        public static IResult CreateNewLanguage(IlanguageRepository languages, LanguageItemPost newLanguageData) 
        {
            return TypedResults.Created("/createLanguage", languages.AddLanguage(newLanguageData.LanguageName));
        }

        public static IResult UpdateLanguage(IlanguageRepository languages, LanguageItemUpdate newLanguageData, string nameToUpdate)
        {
            return TypedResults.Created("/updateLanguage", languages.UpdateLanguage(nameToUpdate, newLanguageData));
        }

        public static IResult RemoveLanguage(IlanguageRepository languages, string name) 
        {
            return TypedResults.Ok(languages.DeleteLanguage(name));
        }
    }

    
}
