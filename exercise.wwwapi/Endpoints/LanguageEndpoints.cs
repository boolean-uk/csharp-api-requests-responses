using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("language")]
    public class LanguageEndpoints : ControllerBase
    {
        public IRepository2 _repository;

        public LanguageEndpoints(IRepository2 repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateLanguage([FromBody] LanguagePost languagePost)
        {
            var newLanguage = new Language() { name = languagePost.name };
            _repository.AddLanguage(newLanguage);
            return Created($"/languages/{newLanguage.Id}", newLanguage);
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetLanguages()
        {
            var languages = _repository.GetLanguages();
            return Ok(languages);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddLanguage([FromBody] LanguagePost name)
        {
            // Validate
            if (name == null)
            {
                return BadRequest("Invalid language data");
            }

            var newLanguage = new Language() { name = name.name };
            _repository.AddLanguage(newLanguage);
            return Created($"/languages/{newLanguage.Id}", newLanguage);
        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateLanguage(int id, [FromBody] LanguagePut name)
        {
            var updatedLanguage = _repository.UpdateLanguage(id, name);
            if (updatedLanguage == null)
            {
                return NotFound($"Language with ID {id} not found");
            }
            return Ok(updatedLanguage);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteLanguage(int id)
        {
            var languageDeleted = _repository.DeleteLanguage(id);
            if (!languageDeleted)
            {
                return NotFound($"Language with ID {id} not found");
            }
            return NoContent();
        }
    }
}
