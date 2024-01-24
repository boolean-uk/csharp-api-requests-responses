using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints
{
    public class LanguageEndpoints
    {
        public static IResult AddLanguage(LanguageCollection languages, string newLanguage)
        {
            Language newLang = new Language(newLanguage);
            languages.Add(newLang);
            return TypedResults.Created($"/languages{newLang.name}", newLang);

        }

        public static IResult GetAllLanguages(LanguageCollection languages)
        {
            return TypedResults.Ok(languages.GetAll());
        }

        public static IResult GetLanguage(LanguageCollection languages, string name)
        {
            Language language = languages.GetLanguage(name);
            return TypedResults.Ok(language);
        }

        public static IResult UpdateLanguage(LanguageCollection languages, string nametoUpdate, string newName)
        {

            try
            {
                Language? updatedLanguage = new Language(newName) ;
                languages.UpdateLanguage(nametoUpdate, updatedLanguage);
                return TypedResults.Created($"/languages{updatedLanguage}", updatedLanguage);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }

        public static IResult DeleteLanguage(LanguageCollection languages, string langName)
        {
            return TypedResults.Ok(languages.RemoveLanguage(langName));
        }
        






    }
}
