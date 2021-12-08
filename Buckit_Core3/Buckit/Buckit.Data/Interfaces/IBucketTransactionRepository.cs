using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Interfaces
{
    public interface IBucketTransactionRepository
    {
        Task<int> AddAsync(BucketTransaction bucketTransaction);
        BucketTransaction? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(BucketTransaction bucketTransaction);
    }
}
