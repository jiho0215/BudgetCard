using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buckit.Model;
//using Microsoft.EntityFrameworkCore;

namespace Buckit.Data
{
    public class AccountRepository : IAccountRepository
    {
        public Task<int> AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
