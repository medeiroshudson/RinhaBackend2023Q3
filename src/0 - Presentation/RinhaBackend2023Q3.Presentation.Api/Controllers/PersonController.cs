using Microsoft.AspNetCore.Mvc;
using RinhaBackend2023Q3.Domain.Entities.Common;
using RinhaBackend2023Q3.Domain.Interfaces.Services;

namespace RinhaBackend2023Q3.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet(Name = "GetAllPerson")]
        public async Task<IActionResult> Get()
        {
            var persons = await _personService.GetAll();
            return StatusCode(StatusCodes.Status200OK, persons);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _personService.Get(id);
            return StatusCode(StatusCodes.Status200OK, person);
        }

        [HttpPost(Name = "AddPerson")]
        public async Task<IActionResult> Add(Person entity)
        {
            await _personService.Add(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpPut(Name = "UpdatePerson")]
        public async Task<IActionResult> Update(Person entity)
        {
            await _personService.Update(entity);
            return StatusCode(StatusCodes.Status202Accepted, entity);
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _personService.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
