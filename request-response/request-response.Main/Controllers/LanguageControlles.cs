using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        public static List<Language> langs = new List<Language>();
        public LanguageController()
        {
            if (langs.Count == 0)
            {
                langs.Add(new Language("Java"));
                langs.Add(new Language("C#"));
                langs.Add(new Language("Python"));
                langs.Add(new Language("Assembly"));
                langs.Add(new Language("SQL"));
            }
        }

        //post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateLanguage(Language lang)
        {
            langs.Add(lang);
            return Results.Ok(lang);
        }

        //get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetLanguage()
        {
            return Results.Ok(langs);
        }

        //get{firstname}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> GetALanguage(string name)
        {
            var lang = langs.Where(s => s.name == name).FirstOrDefault();
            return lang != null ? Results.Ok(lang) : Results.NotFound();
        }

        //update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public async Task<IResult> Update(string name, Language lang)
        {
            //get item to update
            var item = langs.Where(s => s.name == name).FirstOrDefault();

            if (item == null) return Results.NotFound();

            item.name = string.IsNullOrEmpty(lang.name) ? item.name : lang.name;
            item.name = string.IsNullOrEmpty(lang.name) ? item.name : lang.name;

            return Results.Ok(item);
        }

        //delete
        [HttpDelete]
        [Route("{name}")]
        public async Task<IResult> DeleteALanguage(string name)
        {
            var lang = langs.Where(s => s.name == name).FirstOrDefault();
            int result = langs.RemoveAll(s => s.name == name);
            return result >= 0 && lang != null ? Results.Ok(lang) : Results.NotFound();
        }




    }
}