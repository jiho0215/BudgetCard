﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Buckit.Model;

namespace Buckit.Data
{
    public interface IBucketRepository
    {
        Task<int> AddAsync(Bucket bucket);
        Task<Bucket> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Bucket bucket);
    }
}
