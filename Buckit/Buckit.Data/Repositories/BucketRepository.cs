using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data.Repositories
{
    internal class BucketRepository : IBucketRepository
    {
        public Task<int> AddAsync(Bucket bucket)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int bucketId)
        {
            throw new NotImplementedException();
        }

        public Task<Bucket> GetAsync(int bucketId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bucket>> GetBucketsAsync(int buckitUserId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Bucket bucket)
        {
            throw new NotImplementedException();
        }
    }
}
