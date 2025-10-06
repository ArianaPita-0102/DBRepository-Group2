using DBRepository_Group2.Models;
using DBRepository_Group2.Models.Dtos;
using System.Runtime.InteropServices;

namespace DBRepository_Group2.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Create(CreateEventDto dto);
        Task<Event> Update(UpdateEventDto dto, Guid id);
        Task<bool> Delete(Guid id);
    }
}
