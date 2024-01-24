using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.EndPoints
{
    public static class LanguageEndPoints
    {
        public static void LanguageEndPointConfig(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapPost("/CreateNewLanguage", CreateALanguage);
            languageGroup.MapGet("/GetAllLanguages", GetAllLanguages);
            languageGroup.MapGet("/GetALanguage{Name}", GetALanguage);
            languageGroup.MapPut("/UpdateALanguage{Name}", UpdateALanguage);
            languageGroup.MapDelete("/DeleteALanguage{Name}", DeleteALanguage);
        }

        public static IResult CreateALanguage(ILanguageRepository languages, LanguagePostPayload newLanguageData)
        {
            languages.CreateALanguage(newLanguageData.Name);
            return TypedResults.Ok(languages);
        }

        public static IResult GetAllLanguages(ILanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetAllLanguages());
        }

        public static IResult GetALanguage(ILanguageRepository languages, string name)
        {
            return TypedResults.Ok(languages.GetALanguage(name));
        }

        public static IResult UpdateALanguage(ILanguageRepository languages, string name, LanguageUpdateData updateData)
        {

            return TypedResults.Ok(languages.UpdateALanguage(name, updateData));
        }
        public static IResult DeleteALanguage(ILanguageRepository languages, string name)
        {
            return TypedResults.Ok(languages.DeleteALanguage(name));
        }
    }
}
