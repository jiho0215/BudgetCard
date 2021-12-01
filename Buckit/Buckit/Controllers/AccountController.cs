using Microsoft.AspNetCore.Mvc;
using Buckit.Web.Models;
using Buckit.Data;

namespace Buckit.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Index()
        {
            var model = new AccountViewModel()
            {
                AccountLastFourDigit = "This is test"
            };
            return View(model);
        }
    }
}
