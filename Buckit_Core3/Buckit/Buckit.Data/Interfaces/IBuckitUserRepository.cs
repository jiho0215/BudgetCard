using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Interfaces
{
    public interface IBuckitUserRepository
    {
        Task<int> AddAsync(BuckitUser buckitUser);
        BuckitUser? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(BuckitUser buckitUser);
    }
}
