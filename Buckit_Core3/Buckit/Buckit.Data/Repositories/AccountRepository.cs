using Buckit.Data.Interfaces;
using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        buckitdbContext _context;

        public AccountRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<int> AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account.AccountId;
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return;
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public Account? Get(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == id);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
