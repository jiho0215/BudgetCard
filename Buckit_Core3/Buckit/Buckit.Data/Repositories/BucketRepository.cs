using Buckit.Data.Interfaces;
using Buckit.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        buckitdbContext _context;

        public BucketRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<int> AddAsync(Bucket bucket)
        {
            _context.Buckets.Add(bucket);
            await _context.SaveChangesAsync();
            return bucket.BucketId;
        }

        public async Task DeleteAsync(int id)
        {
            var bucket = await _context.Buckets.FindAsync(id);
            if (bucket == null)
            {
                return;
            }
            _context.Buckets.Remove(bucket);
            await _context.SaveChangesAsync();
        }

        public Bucket? Get(int id)
        {
            return _context.Buckets.FirstOrDefault(x => x.BucketId == id);
        }

        public async Task UpdateAsync(Bucket bucket)
        {
            _context.Buckets.Update(bucket);
            await _context.SaveChangesAsync();
        }
    }
}

