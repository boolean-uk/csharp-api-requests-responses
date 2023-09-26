using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private static List<Language> _languages = new List<Language>();

        public LanguageController()
        {
            if (_languages.Count == 0)
            {
                _languages.Add(new Language("C#"));
                _languages.Add(new Language("Java"));
            }
        }

        // create a language
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateALanguage(Language language)
        {
            _languages.Add(language);
            return Results.Created($"http://localhost:5186/Language/{language.Name}", language);
        }

        // get all languages
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetLanguages()
        {
            return Results.Ok(_languages);
        }

        // get a language
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> GetALanguage(string name)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == name);
            return language != null ? Results.Ok(language) : Results.NotFound();
        }

        // update a language
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> UpdateALanguage(string name, Language newLanguage)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == name);
            if (language == null) return Results.NotFound();

            if (!string.IsNullOrEmpty(newLanguage.Name))
            {
                language.Name = newLanguage.Name;
            }

            return Results.Created($"http://localhost:5186/Language/{language.Name}", language);
        }

        // delete a language
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> DeleteALanguage(string name)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == name);
            bool result = _languages.Remove(language);

            if (!result || language == null) return Results.NotFound();
            return Results.Ok(language);
        }
    }
}