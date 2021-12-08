using Buckit.Data.Interfaces;
using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Repositories
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        buckitdbContext _context;

        public AccountTransactionRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<int> AddAsync(AccountTransaction accountTransaction)
        {
            _context.AccountTransactions.Add(accountTransaction);
            await _context.SaveChangesAsync();
            return accountTransaction.AccountTransactionId;
        }

        public async Task DeleteAsync(int id)
        {
            var accountTransaction = await _context.AccountTransactions.FindAsync(id);
            if (accountTransaction == null)
            {
                return;
            }
            _context.AccountTransactions.Remove(accountTransaction);
            await _context.SaveChangesAsync();
        }

        public AccountTransaction? Get(int id)
        {
            return _context.AccountTransactions.FirstOrDefault(x => x.AccountTransactionId == id);
        }

        public async Task UpdateAsync(AccountTransaction accountTransaction)
        {
            _context.AccountTransactions.Update(accountTransaction);
            await _context.SaveChangesAsync();
        }
    }
}
