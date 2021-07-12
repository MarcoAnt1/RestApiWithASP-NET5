using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Business;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _booksBusiness;

        public BookController(IBookBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _booksBusiness.FindById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return Ok(_booksBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return Ok(_booksBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}
