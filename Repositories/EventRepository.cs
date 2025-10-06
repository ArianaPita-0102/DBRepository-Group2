using DBRepository_Group2.Models;
using System;

namespace DBRepository_Group2.Repositories
{
    public class EventRepository: IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Event ev)
        {
            _context.Events.Add(ev);
        }

        public async Task Update(Event ev, Guid id)
        {
            var index = _context.Events.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                _context.Events[index] = ev;
            }
        }

        public async Task Delete(Guid id)
        {
            return await _context.Events.RemoveAll(b => b.Id == id);
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events;
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _context.Events.FirstOrDefault(b => b.Id == id);
        }
    }
}
