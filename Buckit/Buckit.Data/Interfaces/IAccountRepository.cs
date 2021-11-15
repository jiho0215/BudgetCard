using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IAccountRepository
    {
        Task<int> AddAccount(Account account);
        Task<Account> GetAsync(int accountId);
        Task<List<Account>> GetAccountsAsync();
        Task UpdateAsync(Account account);
        Task DeleteAsync(int accountId);

    }
}
