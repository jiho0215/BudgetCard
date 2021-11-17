using Buckit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data
{
    public class BucketRepository : IBucketRepository
    {
        buckitdbContext _context;
        static readonly int DEFAULT_PICTURE = 0;

        public BucketRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public Task<int> AddAsync(Bucket bucket)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Bucket> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Bucket bucket)
        {
            throw new NotImplementedException();
        }
    }
}
