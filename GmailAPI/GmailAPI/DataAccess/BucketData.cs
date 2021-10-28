using GmailAPI.Converters;
using GmailAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.DataAccess
{
    public class BucketData : IBucketData
    {
        private DatabaseConfig myDatabase = new DatabaseConfig();
        private BucketDataConverter bucketDataConverter = new BucketDataConverter();
        public BaseResponse AddAccount(Account inputAccount)
        {
            var response = new BaseResponse();

            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();

                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "INSERT INTO Account (accountnumber, currentbalance) values('" + inputAccount.AccountNumber + "', '" + inputAccount.CurrentBalance + "')";
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }

            }
            response.IsSuccess = true;
            return response;
        }

        public Account GetAccountByAccountNumber(Account inputAccount)
        {
            var returnAccount = new Account();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();

                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "SELECT id, currentbalance, accountnumber FROM Account where accountnumber = '" + inputAccount.AccountNumber + '\'';
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        var convertedAccountList = bucketDataConverter.ConvertToAccountList(myReader);
                        returnAccount = convertedAccountList?[0];
                    }
                }
            }
            //if (returnAccount.AccountId == null || returnAccount.AccountId == 0)
            //{
            //    var response = AddAccount(inputAccount);
            //    if (response.IsSuccess)
            //    {
            //        return GetAccountByAccountNumber(inputAccount);
            //    }
            //    else
            //    {
            //        throw new Exception(response.ErrorMessage);
            //    }
            //}

            return returnAccount;
        }

        //public List<Account> GetAccountsByUser()
        //{

        //}

        //public List<Account> GetAccountsByBucket()

        public BaseResponse AddBucket(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Bucket> GetAllBuckets()
        {
            var returnBucketList = new List<Bucket>();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();

                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "SELECT id, targetAmount, description, type, balance, startdate, enddate FROM Bucket";
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        returnBucketList = bucketDataConverter.ConvertToBucketList(myReader);
                    }
                }
            }
            return returnBucketList;
        }

        public Bucket GetBucket(Bucket bucket)
        {
            var returnBucket = new Bucket();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();

                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "SELECT id, currentbalance, accountnumber FROM Account where accountnumber = '" + inputAccount.AccountNumber + '\'';
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        var convertedBucketList = bucketDataConverter.ConvertToBucketList(myReader);
                        returnBucket = convertedBucketList?[0];
                    }
                }
            }
            return returnBucket;
        }

        public BaseResponse GetTransaction(Account account)
        {
            throw new NotImplementedException();
        }


        public BaseResponse AddTransaction(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse SoftDeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse SoftDeleteBucket(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse SoftDeleteTransaction(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateBucket(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateTransaction(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
