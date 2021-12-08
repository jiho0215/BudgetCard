using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyShuttle.Model.Models;

namespace MyShuttle.Data
{
    public interface IBuckitUserRepository
    {
        Task<int> AddAsync(BuckitUser buckitUser);
    }
}
