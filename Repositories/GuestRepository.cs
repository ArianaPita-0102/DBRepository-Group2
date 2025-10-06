using DBRepository_Group2.Models;
using DBRepository_Group2.Data;
using Microsoft.EntityFrameworkCore;

namespace DBRepository_Group2.Repositories
{
    public class GuestRepository : IGuestRepository
    {

        private readonly AppDbContext _context;

        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
        }

        public async Task Delete(Guid id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.Id == id);
            if(guest != null)
            {
                _context.Guests.Remove(guest);
            }
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            return await _context.Guests.FirstOrDefaultAsync(g=> g.Id == id);
        }

    }
}
