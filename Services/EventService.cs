using DBRepository_Group2.Models;
using DBRepository_Group2.Models.Dtos;
using DBRepository_Group2.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

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
            var ev = new Event(){
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date=DateTime.Now,
                Capacity = dto.Capacity
            };
            _repo.Add(ev);
            return ev;
        }
        public async Task<Event> Update(UpdateEventDto dto, Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return null;
            var updated = new Event()
            {
                Id = id,
                Title = dto.Title.Trim(),
                Date = dto.Date,
                Capacity = dto.Capacity
            };
            await _repo.Update(updated, id);
            return updated;
        }
        public async Task<bool> Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Event?> GetById(Guid id)
        {
            var ev = _repo.GetById(id);
            return await ev;
        }
    }
}
