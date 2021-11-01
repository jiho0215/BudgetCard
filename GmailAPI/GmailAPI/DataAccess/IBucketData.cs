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
        Account GetAccountByAccountNumber(Account inputAccount);
        Bucket GetBucket(Bucket inputBucket);
        Transaction GetTransaction(Transaction account);
        BaseResponse AddAccount(Account account);
        BaseResponse AddBucket(Bucket bucket);
        BaseResponse AddTransaction(Transaction account);
        BaseResponse UpdateAccount(Account account);
        BaseResponse UpdateBucket(Bucket account);
        BaseResponse UpdateTransaction(Transaction account);
        BaseResponse SoftDeleteAccount(Account account);
        BaseResponse SoftDeleteBucket(Bucket account);
        BaseResponse SoftDeleteTransaction(Transaction account);
        BaseResponse AddAccountSnapshot(DailySummary dailySummary);
        BaseResponse DeleteAccountSnapshot(DailySummary dailySummary);
        AccountSnapshot GetAccountSnapshot(DailySummary dailySummary);
    }
}
