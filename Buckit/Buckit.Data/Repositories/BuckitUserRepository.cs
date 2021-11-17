using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public class BuckitUserRepository : IBuckitUserRepository
    {
        buckitdbContext _context;

        public BuckitUserRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<int> AddAsync(BuckitUser buckitUser)
        {
            _context.BuckitUsers.Add(buckitUser);
            await _context.SaveChangesAsync();
            return buckitUser.BuckitUserId;
        }

        public async Task DeleteAsync(int id)
        {
            var buckitUser = await _context.BuckitUsers.FindAsync(id);
            if (buckitUser == null)
            {
                return;
            }
            _context.BuckitUsers.Remove(buckitUser);
            await _context.SaveChangesAsync();
        }

        public BuckitUser? Get(int id)
        {
            return _context.BuckitUsers.FirstOrDefault(x => x.BuckitUserId == id);
        }

        public async Task UpdateAsync(BuckitUser buckitUser)
        {
            _context.BuckitUsers.Update(buckitUser);
            await _context.SaveChangesAsync();
        }
    }
}
