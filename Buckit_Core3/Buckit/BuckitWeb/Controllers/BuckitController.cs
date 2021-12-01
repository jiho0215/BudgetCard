using Buckit.Data.Models;
using BuckitWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuckitWeb
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuckitController : Controller
    {
        private readonly BuckitContext _context;
        private readonly BuckitService _buckitService;

        public BuckitController(BuckitContext context)
        {
            _context = context;
        }

        // GET: api/Buckit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bucket>>> GetBuckit()
        {
            var buckitUserId = 1;
            return await _buckitService.GetAllBuckets(buckitUserId);
        }
    }
}
