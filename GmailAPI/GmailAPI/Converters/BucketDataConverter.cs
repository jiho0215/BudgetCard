using GmailAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.Converters
{
    public class BucketDataConverter
    {
        public List<Bucket> ConvertToBucketList(SQLiteDataReader myReader)
        {
            var returnBucketList = new List<Bucket>();
            while (myReader.Read())
            {
                var bucket = new Bucket();

                Int32.TryParse(myReader["Id"].ToString(), out var id);
                bucket.BucketId = id;
                float.TryParse(myReader["TargetAmount"].ToString(), out var targetAmount);
                bucket.TargetAmount = targetAmount;
                float.TryParse(myReader["balance"].ToString(), out var balance);
                bucket.Balance = balance;
                bucket.Description = myReader["description"].ToString();
                bucket.Type = myReader["type"].ToString();
                DateTime.TryParse(myReader["StartDate"].ToString(), out var startDate);
                bucket.StartDate = startDate;
                DateTime.TryParse(myReader["EndDate"].ToString(), out var endDate);
                bucket.EndDate = endDate;
                if (bucket.BucketId != null && bucket.BucketId > -1)
                {
                    returnBucketList.Add(bucket);
                }
            }
            return returnBucketList;
        }

        public List<Account> ConvertToAccountList(SQLiteDataReader myReader)
        {
            var returnAccountList = new List<Account>();
            while (myReader.Read())
            {
                var returnAccount = new Account();

                Int32.TryParse(myReader["Id"].ToString(), out var id);
                returnAccount.AccountId = id;
                float.TryParse(myReader["CurrentBalance"].ToString(), out var currentBalance);
                returnAccount.CurrentBalance = currentBalance;
                returnAccount.LastFourDigits = myReader["Accountnumber"].ToString();
                if (returnAccount.AccountId != null && returnAccount.AccountId > -1)
                {
                    returnAccountList.Add(returnAccount);
                }
            }
            return returnAccountList;
        }

        public List<Transaction> ConvertToTransactionList(SQLiteDataReader myReader)
        {
            var returnTransactionList = new List<Transaction>();
            while (myReader.Read())
            {
                var transaction = new Transaction();

                Int32.TryParse(myReader["Id"].ToString(), out var id);
                transaction.TransactionId = id;
                Int32.TryParse(myReader["BucketId"].ToString(), out var bucketId);
                transaction.BucketId = bucketId;
                float.TryParse(myReader["Amount"].ToString(), out var amount);
                transaction.Amount = amount;
                transaction.Type = myReader["type"].ToString();
                transaction.Description = myReader["description"].ToString();

                DateTime.TryParse(myReader["Datetime"].ToString(), out var datetime);
                transaction.DateTime = datetime;
                if (transaction.TransactionId != null && transaction.TransactionId > -1)
                {
                    returnTransactionList.Add(transaction);
                }
            }
            return returnTransactionList;
        }

        public List<AccountSnapshot> ConvertToAccountSnapthotList(SQLiteDataReader myReader)
        {
            var returnAccountSnapshotList = new List<AccountSnapshot>();
            while (myReader.Read())
            {
                var accountSnapshot = new AccountSnapshot();

                Int32.TryParse(myReader["Id"].ToString(), out var id);
                accountSnapshot.AccountSnapshotId = id;
                Int32.TryParse(myReader["accountid"].ToString(), out var accountId);
                accountSnapshot.AccountId = accountId;
                float.TryParse(myReader["CurrentBalance"].ToString(), out var currentBalance);
                accountSnapshot.CurrentBalance = currentBalance;
                float.TryParse(myReader["TotalDeposit"].ToString(), out var totalDeposit);
                accountSnapshot.TotalDeposit = totalDeposit;
                float.TryParse(myReader["TotalWithdrawal"].ToString(), out var totalWithdrawal);
                accountSnapshot.TotalWithdrawal = totalWithdrawal;
                DateTime.TryParse(myReader["DateTime"].ToString(), out var datetime);
                accountSnapshot.DateTime = datetime;
                if (accountSnapshot.AccountSnapshotId != null && accountSnapshot.AccountSnapshotId > -1)
                {
                    returnAccountSnapshotList.Add(accountSnapshot);
                }
            }
            return returnAccountSnapshotList;
        }
    }
}
