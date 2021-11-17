using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IAccountRepository
    {
        Task<int> AddAsync(Account account);
        Account? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Account account);

    }
}
