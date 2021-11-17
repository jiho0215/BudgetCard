using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IBucketTransactionRepository
    {
        Task<int> AddAsync(BucketTransaction bucketTransaction);
        BucketTransaction? Get(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(BucketTransaction bucketTransaction);
    }
}
