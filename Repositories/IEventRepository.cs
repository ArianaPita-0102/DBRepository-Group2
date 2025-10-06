using DBRepository_Group2.Models;

namespace DBRepository_Group2.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event eve);
        Task Update(Event eve, Guid id);
        Task Delete(Guid id);
    }
}
