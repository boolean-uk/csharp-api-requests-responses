using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace request_response.Controllers
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
    /// Used DTO object to define data
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private static List<Language> _languages = new List<Language>();

        static LanguageController() // used the top 30 most used languages
        {
            if (_languages.Count == 0)
            {
                _languages.Add(new Language() { Name = "C#" });
                _languages.Add(new Language() { Name = "C" });
                _languages.Add(new Language() { Name = "C++" });
                _languages.Add(new Language() { Name = "Python" });
                _languages.Add(new Language() { Name = "JavaScript" });
                _languages.Add(new Language() { Name = "TypeScript" });
                _languages.Add(new Language() { Name = "Ruby" });
                _languages.Add(new Language() { Name = "PHP" });
                _languages.Add(new Language() { Name = "Swift" });
                _languages.Add(new Language() { Name = "Go" });
                _languages.Add(new Language() { Name = "Rust" });
                _languages.Add(new Language() { Name = "Kotlin" });
                _languages.Add(new Language() { Name = "Perl" });
                _languages.Add(new Language() { Name = "Scala" });
                _languages.Add(new Language() { Name = "Lua" });
                _languages.Add(new Language() { Name = "R" });
                _languages.Add(new Language() { Name = "SQL" });
                _languages.Add(new Language() { Name = "HTML/CSS" });
                _languages.Add(new Language() { Name = "Haskell" });
                _languages.Add(new Language() { Name = "MATLAB" });
                _languages.Add(new Language() { Name = "Objective-C" });
                _languages.Add(new Language() { Name = "Pascal" });
                _languages.Add(new Language() { Name = "Fortran" });
                _languages.Add(new Language() { Name = "Groovy" });
                _languages.Add(new Language() { Name = "Shell Scripting" });
                _languages.Add(new Language() { Name = "Erlang" });
                _languages.Add(new Language() { Name = "COBOL" });
                _languages.Add(new Language() { Name = "Prolog" });
                _languages.Add(new Language() { Name = "Lisp" });
                _languages.Add(new Language() { Name = "Java" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateLanguage([FromBody] CreateLanguage languageDto)
        {
            return await Task.Run(() =>
            {
                var language = new Language { Name = languageDto.Name };
                _languages.Add(language);
                return Results.Created($"/languages/{languageDto.Name}", language);
            });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllLanguages()
        {
            return await Task.Run(() => Results.Ok(_languages));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetLanguage(string name)
        {
            return await Task.Run(() =>
            {
                var language = _languages.FirstOrDefault(l => l.Name == name);
                if (language == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(language);
            });
        }

        [HttpPut("{name}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> UpdateLanguage(string name, [FromBody] CreateLanguage languageDto)
        {
            return await Task.Run(() =>
            {
                var language = _languages.FirstOrDefault(l => l.Name == name);
                if (language == null)
                {
                    return Results.NotFound();
                }
                language.Name = languageDto.Name;
                return Results.Created($"/languages/{languageDto.Name}", language);
            });
        }

        [HttpDelete("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> DeleteLanguage(string name)
        {
            return await Task.Run(() =>
            {
                var language = _languages.FirstOrDefault(l => l.Name == name);
                if (language == null)
                {
                    return Results.NotFound();
                }
                _languages.Remove(language);
                return Results.Ok(language);
            });
        }
    }
}