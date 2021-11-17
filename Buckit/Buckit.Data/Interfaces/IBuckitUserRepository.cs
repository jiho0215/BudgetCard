using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IBuckitUserRepository
    {
        Task<int> AddAsync(BuckitUser buckitUser);
        Task<BuckitUser> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(BuckitUser buckitUser);
    }
}
