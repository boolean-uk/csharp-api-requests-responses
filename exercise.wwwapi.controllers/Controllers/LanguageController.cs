using exercise.wwwapi.controllers.Data;
using exercise.wwwapi.controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.controllers.Controllers
{
    [ApiController]
    [Route("api/language/[controller]")]
    public class LanguageController : ControllerBase
    {
        List<Language> languages = LanguageData.GetAll();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/create/")]
        public ActionResult CreateLanguage(Language language)
        {
            LanguageData.Add(new Language(language.name));

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/language/")]
        public ActionResult GetLanguages()
        {
            var languages = LanguageData.GetAll();
            return Ok(languages);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/language/{name}")]
        public ActionResult GetALanguage(string name)
        {
            var language = languages.FirstOrDefault(l => l.name == name);
            return Ok(language);
        }

        //update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("language/update/{name}")]
        public ActionResult UpdateLanguage(string name, string newName)
        {
            var language = languages.FirstOrDefault(l => l.name == name);

            if (language != null)
            {
                language.name = newName;

                //SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("language/delete/")]
        public ActionResult<Student> DeleteStudent(string name)
        {
            try
            {
                var languageToDelete = languages.FirstOrDefault(l => l.name == name);

                if (languageToDelete == null)
                {
                    return NotFound($"Language with name = {name} not found");
                }

                LanguageData.Delete(languageToDelete);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }


    }
}
