using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace DBRepository_Group2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOne(Guid id)
        {
            var event = _service.GetById(id);
            return event == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(event);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var event = _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = event.Id }, event);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id){ }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var success = _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}
