using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Business;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IPersonBusiness _personBusiness;

        public PersonController(ILogger<CalculatorController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
