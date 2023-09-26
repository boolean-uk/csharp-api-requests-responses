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
                _languages.Add(new Language() { name = "Java" });
                //_students.Add(_students.Last());
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("addLanguage")]
        public async Task<IResult> AddLanguage(Language language)
        {
            _languages.Add(language);
            return Results.Created($"https://localhost:7241/Language/addStudent", language);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("getLanguage")]
        public async Task<IResult> GetLanguage()
        {
            return Results.Ok(_languages);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{language}")]
        public async Task<IResult> GetALanguage(string name)
        {
            var languages = _languages.Where(l => l.name == name).FirstOrDefault();
            return languages != null ? Results.Ok(_languages) : Results.NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("updateLanguage")]
        public async Task<IResult> UpdateLanguage(string name, Language language)
        {
            var item = _languages.Where(x => x.name == name).FirstOrDefault();
            item.name = language.name != string.Empty ? language.name : item.name;
            return Results.Created($"https://localhost:7241/language/updateStudent", item);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("deleteLanguage/{name}")]
        public async Task<IResult> DeleteLanguage(string name)
        {
            var languages = _languages.Where(s => s.name == name).FirstOrDefault();
            var result = _languages.RemoveAll(s => s.name == name);

            return result >= 0 && languages != null ? Results.Ok(_languages) : Results.NotFound();
        }
    }
}