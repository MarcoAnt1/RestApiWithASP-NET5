using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Business;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksBusiness _booksBusiness;

        public BooksController(IBooksBusiness booksBusiness)
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
        public IActionResult Create([FromBody] Book books)
        {
            if (books == null)
                return BadRequest();

            return Ok(_booksBusiness.Create(books));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book books)
        {
            if (books == null)
                return BadRequest();

            return Ok(_booksBusiness.Update(books));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}
