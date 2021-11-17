using Buckit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckit.Data
{
    public class BucketTransactionRepository : IBucketTransactionRepository
    {
        buckitdbContext _context;

        public BucketTransactionRepository(buckitdbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<int> AddAsync(BucketTransaction bucketTransaction)
        {
            _context.BucketTransactions.Add(bucketTransaction);
            await _context.SaveChangesAsync();
            return bucketTransaction.BucketTransactionId;
        }

        public async Task DeleteAsync(int id)
        {
            var bucketTransaction = await _context.BucketTransactions.FindAsync(id);
            if (bucketTransaction == null)
            {
                return;
            }
            _context.BucketTransactions.Remove(bucketTransaction);
            await _context.SaveChangesAsync();
        }

        public BucketTransaction? Get(int id)
        {
            return _context.BucketTransactions.FirstOrDefault(x => x.BucketId == id);
        }

        public async Task UpdateAsync(BucketTransaction bucketTransaction)
        {
            _context.BucketTransactions.Update(bucketTransaction);
            await _context.SaveChangesAsync();
        }
    }
}
