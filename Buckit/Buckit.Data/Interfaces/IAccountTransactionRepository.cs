using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IAccountTransactionRepository
    {
        Task<int> AddAsync(Transaction transaction);
        Task<Transaction> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Transaction transaction);
    }
}
