using Buckit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        buckitdbContext _context;
        static readonly int DEFAULT_PICTURE = 0;

        public AccountTransactionRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public Task<int> AddAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
