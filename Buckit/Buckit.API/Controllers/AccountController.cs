using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buckit.Data;

namespace Buckit.API.Controllers
{
    public class AccountController : ControllerBase
    {
        IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account? Get(int id)
        {
            return _accountRepository.Get(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Account account)
        {
            return await _accountRepository.AddAsync(account);
        }

        [HttpPut]
        public async Task Put([FromBody] Account account)
        {
            await _accountRepository.UpdateAsync(account);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _accountRepository.DeleteAsync(id);
        }
    }
}
