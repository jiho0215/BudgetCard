using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> AddAsync(Account account);
        Account? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Account account);
    }
}
