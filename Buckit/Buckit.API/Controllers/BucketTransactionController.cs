using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buckit.Data;

namespace Buckit.API.Controllers
{
    public class BucketTransactionController : ControllerBase
    {
        IBucketTransactionRepository _bucketTransactionRepository;

        public BucketTransactionController(IBucketTransactionRepository bucketTransactionRepository)
        {
            _bucketTransactionRepository = bucketTransactionRepository;
        }

        public BucketTransaction? Get(int id)
        {
            return _bucketTransactionRepository.Get(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] BucketTransaction bucketTransaction)
        {
            return await _bucketTransactionRepository.AddAsync(bucketTransaction);
        }

        [HttpPut]
        public async Task Put([FromBody] BucketTransaction bucketTransaction)
        {
            await _bucketTransactionRepository.UpdateAsync(bucketTransaction);
        }

        [HttpDelete]
        public async Task Delete([FromBody] int id)
        {
            await _bucketTransactionRepository.DeleteAsync(id);
        }

    }
}
