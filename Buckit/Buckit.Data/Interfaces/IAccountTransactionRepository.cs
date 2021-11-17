using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buckit.Data
{
    public interface IAccountTransactionRepository
    {
        Task<int> AddAsync(AccountTransaction transaction);
        AccountTransaction? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(AccountTransaction transaction);
    }
}
