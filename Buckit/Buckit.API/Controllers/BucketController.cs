using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buckit.Data;

namespace Buckit.API.Controllers
{
    internal class BucketController : ControllerBase
    {
        IBucketRepository _bucketRepository;

        public BucketController(IBucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }

        public Bucket? Get(int id)
        {
            return _bucketRepository.Get(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Bucket bucket)
        {
            return await _bucketRepository.AddAsync(bucket);
        }

        [HttpPut]
        public async Task Put([FromBody] Bucket bucket)
        {
            await _bucketRepository.UpdateAsync(bucket);
        }

        [HttpDelete]
        public async Task Delete([FromBody] int id)
        {
            await _bucketRepository.DeleteAsync(id);
        }
    }
}
