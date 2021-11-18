using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buckit.Data;

namespace Buckit.API.Controllers
{
    public class AccountTransactionController : ControllerBase
    {
        IAccountTransactionRepository _accountTransactionRepository;

        public AccountTransactionController(IAccountTransactionRepository accountTransactionRepository)
        {
            _accountTransactionRepository = accountTransactionRepository;
        }

        public AccountTransaction? Get(int id)
        {
            return _accountTransactionRepository.Get(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] AccountTransaction accountTransaction)
        {
            return await _accountTransactionRepository.AddAsync(accountTransaction);
        }

        [HttpPut]
        public async Task Put([FromBody] AccountTransaction accountTransaction)
        {
            await _accountTransactionRepository.UpdateAsync(accountTransaction);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _accountTransactionRepository.DeleteAsync(id);
        }
    }

}
