using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface ITransactionRepository
    {
        Task<int> AddAsync(ITransactionRepository transaction);
        Task DeleteAsync(int transactionId);
        Task<ITransactionRepository> GetAsync(int transactionId);
        Task<IEnumerable<ITransactionRepository>> GetTransactionsAsync();
        Task UpdateAsync(ITransactionRepository transaction);
    }
}
