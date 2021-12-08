using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Interfaces
{
    public interface IAccountTransactionRepository
    {
        Task<int> AddAsync(AccountTransaction transaction);
        AccountTransaction? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(AccountTransaction transaction);
    }
}
