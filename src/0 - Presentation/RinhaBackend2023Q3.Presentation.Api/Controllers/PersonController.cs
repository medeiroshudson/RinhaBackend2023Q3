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
        public IEnumerable<Person> Get()
        {
            return _personService.GetAll();
        }
    }
}