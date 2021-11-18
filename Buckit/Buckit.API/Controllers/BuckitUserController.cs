using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buckit.Data;

namespace Buckit.API.Controllers
{
    public class BuckitUserController : ControllerBase
    {
        IBuckitUserRepository _buckitUserRepository;

        public BuckitUserController(IBuckitUserRepository buckitUserRepository)
        {
            _buckitUserRepository = buckitUserRepository;
        }

        public BuckitUser? Get(int id)
        {
            return _buckitUserRepository.Get(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] BuckitUser buckitUser)
        {
            return await _buckitUserRepository.AddAsync(buckitUser);
        }
        [HttpPut]
        public async Task Put([FromBody] BuckitUser buckitUser)
        {
            await _buckitUserRepository.UpdateAsync(buckitUser);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _buckitUserRepository.DeleteAsync(id);
        }
    }
}
