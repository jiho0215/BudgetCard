using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public class BuckitUserRepository : IBuckitUserRepository
    {
        buckitdbContext _context;
        static readonly int DEFAULT_PICTURE = 0;

        public BuckitUserRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public Task<int> AddAsync(BuckitUser buckitUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BuckitUser> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BuckitUser buckitUser)
        {
            throw new NotImplementedException();
        }
    }
}
