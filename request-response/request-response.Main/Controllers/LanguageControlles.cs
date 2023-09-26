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

    }
}