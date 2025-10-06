using DBRepository_Group2.Models.Dtos;
using DBRepository_Group2.Services;
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
        public async Task<IActionResult> GetOne(Guid id)
        {
            var ev = await _service.GetById(id);
            return ev == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ev = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ev.Id }, ev);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            if (dto == null) return NotFound();
            else return Ok(await _service.Update(dto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}
