using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IBucketRepository
    {
		Task<int> AddAsync(Bucket bucket);
		Task DeleteAsync(int bucketId);
		Task<Bucket> GetAsync(int bucketId);
		Task<IEnumerable<Bucket>> GetBucketsAsync(int buckitUserId);
		Task UpdateAsync(Bucket bucket);
	}
}
