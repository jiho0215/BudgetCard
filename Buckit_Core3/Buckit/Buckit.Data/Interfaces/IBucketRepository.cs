using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Interfaces
{
    public interface IBucketRepository
    {
        Task<int> AddAsync(Bucket bucket);
        Bucket? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Bucket bucket);
    }
}
