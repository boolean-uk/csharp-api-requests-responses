using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("languages")]
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllLanguages()
        {
            return Results.Ok(_languages);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddLanguage(Language language)
        {
            _languages.Add(language);
            return Results.Created($"http://www.boolean.com/languages/{language.name}", language);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> GetLanguageByName(string name)
        {
            var language = _languages.Where(l => l.name == name).FirstOrDefault();
            return language != null ? Results.Ok(language) : Results.NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> DeleteLanguage(string name)
        {
            var language = _languages.Where(l => l.name == name).FirstOrDefault();
            int result = _languages.RemoveAll(l => l.name == name);
            return result >= 0 && language != null ? Results.Ok(language) : Results.NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> UpdateLanguage(string name, Language language)
        {
            var item = _languages.Where(l => l.name == name).FirstOrDefault();

            if (item == null) return Results.NotFound();

            item.name = string.IsNullOrEmpty(language.name) ? item.name : language.name;

            return Results.Created($"http://www.boolean.com/languages/{language.name}", language);
        }
    }
}