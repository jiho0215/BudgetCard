using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IBuckitUserRepository
    {
        Task<int> AddAsync(BuckitUser buckitUser);
        Task DeleteAsync(int buckitUserId);
        Task<BuckitUser> GetAsync(int buckitUserId);
        Task<IEnumerable<Bucket>> GetBuckitUsersAsync();
        Task UpdateAsync(BuckitUser buckitUser);
    }
}
