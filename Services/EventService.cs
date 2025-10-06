using DBRepository_Group2.Models;
using DBRepository_Group2.Models.Dtos;

namespace DBRepository_Group2.Services
{
    public class EventService: IEventService
    {
        private readonly IEventRepository _repo;
        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }
        public Event Create(CreateEventDto dto)
        {
            var event = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date=DateTime.Now,
                Capacity = dto.Capacity
            };
            _repo.Add(event);
            return event;
        }
        public Event Update(UpdateEventDto dto)
        {

        }
        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            _repo.Delete(id);
            return true;
        }

        public IEnumerable<Event> GetAll()
        {
            return _repo.GetAll();
        }

        public Event? GetById(Guid id)
        {
            var event = _repo.GetById(id);
            return event;
        }
    }
}
