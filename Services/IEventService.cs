using DBRepository_Group2.Models;
using DBRepository_Group2.Models.Dtos;
using System.Runtime.InteropServices;

namespace DBRepository_Group2.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();
        Event? GetById(Guid id);
        Event Create(CreateEventDto dto);
        Event Update(UpdateEventDto dto);
        bool Delete(Guid id);
    }
}
