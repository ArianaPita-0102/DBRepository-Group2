using DBRepository_Group2.Models;

namespace DBRepository_Group2.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add(Guest guest);
        Task Delete(Guid id);
    }
}

