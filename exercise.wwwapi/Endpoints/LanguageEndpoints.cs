using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static IResult CreateLanguage(LanguageCollection languages, string language)
        {
            Language newLanguage = languages.Create(language);

            return Results.Created($"/CreateLanguage/{language}", newLanguage);
        }

        public static IResult GetAllLanguages(LanguageCollection languages)
        {
            var allLanguages = languages.GetAll();
            return Results.Ok(allLanguages);
        }




        public static IResult GetALanguage(LanguageCollection languages, string name )
        {
            var language = languages.GetAll().Find(l => l.name == name);

            if (language != null)
            {
                return TypedResults.Ok(language);
            }
            else
            {
                return Results.NotFound($"Language {language} not found");
            }
        }


        public static IResult UpdateALanguage(LanguageCollection language, string Name, string NewName)
        {
            var findLanguage = language.GetAll().FirstOrDefault(l => l.name == Name);

            if (findLanguage != null)
            {
                findLanguage.name = NewName;
                return TypedResults.Created($"/UpdatedLanguage/{NewName}", findLanguage);
            }
            else
            {
                return Results.NotFound($"Language {Name} not found");
            }
        }

        public static IResult DeleteLanguage(LanguageCollection languages, string Name)
        {
            var language = languages.GetAll().FirstOrDefault(l => l.name == Name);

            if (language != null)
            {
                languages.Remove(language);
            
                return TypedResults.Ok(language);
            }
            else
            {
                return Results.NotFound($"Language {language} not found");
            }
        }

    }
}
