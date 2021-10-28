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
                if (bucket.BucketId != null && bucket.BucketId > 0)
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
                returnAccount.AccountNumber = myReader["Accountnumber"].ToString();
                if (returnAccount.AccountId != null && returnAccount.AccountId > 0)
                {
                    returnAccountList.Add(returnAccount);
                }
            }
            return returnAccountList;
        }
    }
}
