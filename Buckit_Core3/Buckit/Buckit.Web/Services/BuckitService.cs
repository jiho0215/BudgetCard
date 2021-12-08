using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Buckit.Data.Models;

namespace Buckit.Web.Services
{
    public class BuckitService
    {
        private readonly BuckitContext _context;
        private IConfiguration _configuration;

        public BuckitService(BuckitContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Bucket>> GetAllBuckets(int buckitUserId)
        {
            var bucketsToReturn = _context.Buckets.Where(x => x.BuckitUserId == buckitUserId);
            return await bucketsToReturn.ToListAsync();
        }
    }
}
