using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<int> AddAsync(ITransactionRepository transaction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<ITransactionRepository> GetAsync(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITransactionRepository>> GetTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ITransactionRepository transaction)
        {
            throw new NotImplementedException();
        }
    }
}
