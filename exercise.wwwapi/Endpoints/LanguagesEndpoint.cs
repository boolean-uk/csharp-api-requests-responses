using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi
{
    public static class LanguagesEndpoint
    {
        public static void ConfigureLanguagesEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetAll);
            languages.MapPost("/", Add);
            languages.MapDelete("/{name}", Delete);
            languages.MapPut("/{name}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(LanguagesRepository languagesRepository)
        {
            var languages = languagesRepository.GetAll();
            return Results.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Add(LanguagesRepository languagesRepository, string name)
        {
            Language language = new Language(name);
            languagesRepository.Add(language);

            return Results.Created($"https://localhost:7010/languages/{language.Name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(LanguagesRepository languagesRepository, string name)
        {
            var language = languagesRepository.Get(name);
            if (language != null && languagesRepository.Delete(name))
            {
                return Results.Ok(new { Status = "Deleted", Language = language });
            }
            return Results.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(LanguagesRepository languagesRepository, string name, string newName)
        {
            var language = languagesRepository.Get(name);
            if (language == null) return Results.NotFound();

            var updatedLanguage = languagesRepository.Update(name, newName);
            if (updatedLanguage != null)
            {
                return Results.Ok(updatedLanguage);
            }

            return Results.BadRequest();
        }
    }
}
