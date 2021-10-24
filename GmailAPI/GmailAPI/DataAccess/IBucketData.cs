using GmailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.DataAccess
{
    public interface IBucketData
    {
        BaseResponse GetAccountByAccountNumber(Account account);
        BaseResponse GetBucket(Account account);
        BaseResponse GetTransaction(Account account);
        BaseResponse AddAccount(Account account);
        BaseResponse AddBucket(Account account);
        BaseResponse AddTransaction(Account account);
        BaseResponse UpdateAccount(Account account);
        BaseResponse UpdateBucket(Account account);
        BaseResponse UpdateTransaction(Account account);
        BaseResponse SoftDeleteAccount(Account account);
        BaseResponse SoftDeleteBucket(Account account);
        BaseResponse SoftDeleteTransaction(Account account);
    }
}
