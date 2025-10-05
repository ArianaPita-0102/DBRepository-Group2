using DBRepository_Group2.Models;
using DBRepository_Group2.Models.dtos;

namespace DBRepository_Group2.Services
{
    public interface IGuestService
    {
        Task<Guest> Create(CreateGuestDto dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
    }
}
