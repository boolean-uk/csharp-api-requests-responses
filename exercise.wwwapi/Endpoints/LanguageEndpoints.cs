using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;


namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/", GetAll);
            languages.MapGet("/{name}", GetA);
            languages.MapPost("/{language}", Create);
            languages.MapPut("/{name}", Update);
            languages.MapDelete("/{name}", Delete);

        }

        private static IResult GetAll(LanguageRepository repo) => TypedResults.Ok(repo.GetAll());

        private static IResult GetA(LanguageRepository repo, string name) => TypedResults.Ok(repo.GetA(name));

        private static IResult Create(LanguageRepository repo, Language language) => TypedResults.Created($"http://localhost:5115/book/id/{language.Name}", repo.Create(language));

        private static IResult Update(LanguageRepository repo, string name) => TypedResults.Created($"http://localhost:5115/book/id/{name}", repo.Update(name));

        private static IResult Delete(LanguageRepository repo, string name) => TypedResults.Ok(repo.Delete(name));
    }
}
