using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data.Repositories
{
    public class BuckitUserRepository : IBuckitUserRepository
    {
        public Task<int> AddAsync(BuckitUser buckitUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int buckitUserId)
        {
            throw new NotImplementedException();
        }

        public Task<BuckitUser> GetAsync(int buckitUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bucket>> GetBuckitUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BuckitUser buckitUser)
        {
            throw new NotImplementedException();
        }
    }
}
