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
                    selectCMD.CommandText = "INSERT INTO Account (accountnumber, currentbalance) values('" 
                        + inputAccount.LastFourDigits + "', '" + inputAccount.CurrentBalance + "')";
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
                    selectCMD.CommandText = "SELECT id, currentbalance, accountnumber FROM Account where accountnumber = '" 
                        + inputAccount.LastFourDigits + '\'';
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

        public BaseResponse AddBucket(Bucket inputBucket)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "INSERT INTO Bucket " +
                        "(targetamount, description, type, balance, startdate, enddate) " +
                        "values('" +
                        inputBucket.TargetAmount + "', '" +
                        inputBucket.Description + "', '" +
                        inputBucket.Type + "', '" +
                        inputBucket.Balance + "', '" +
                        inputBucket.StartDate + "', '" +
                        inputBucket.EndDate +
                        "')";
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
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
                    selectCMD.CommandText = "SELECT id, targetAmount, description, type, balance, startdate, enddate FROM Bucket where bucketid =" + bucket.BucketId;
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

        public Transaction GetTransaction(Transaction transaction)
        {
            var returnTransaction = new Transaction();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();

                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "SELECT id, targetAmount, description, type, balance, startdate, enddate from Trans where Id =" + transaction.TransactionId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        var convertedTransactionList = bucketDataConverter.ConvertToTransactionList(myReader);
                        returnTransaction = convertedTransactionList?[0];
                    }
                }
            }
            return returnTransaction;
        }


        public BaseResponse AddTransaction(Transaction inputTransaction)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "INSERT INTO Trans " +
                        "(datetime, amount, type, description, bucketid) " +
                        "values('" +
                        inputTransaction.DateTime.ToString("yyyy/MM/dd hh:mm") + "', '" +
                        //inputTransaction.DateTime.TimeOfDay + "', '" +
                        inputTransaction.Amount + "', '" +
                        inputTransaction.Type + "', '" +
                        inputTransaction.Description + "', '" +
                        inputTransaction.BucketId +
                        "')";
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }

        public BaseResponse SoftDeleteAccount(Account inputAccount)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "Update Account " +
                        " set DeleteFlag = 1 " +
                        " where id = " + inputAccount.AccountId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }

        public BaseResponse SoftDeleteBucket(Bucket inputBucket)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "Update Bucket" +
                        " set DeleteFlag = 1 " +
                        " where id = " + inputBucket.BucketId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }

        public BaseResponse SoftDeleteTransaction(Transaction transaction)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "Update Trans" +
                        " set DeleteFlag = 1 " +
                        " where id = " + transaction.TransactionId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }

        public BaseResponse UpdateAccount(Account account)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "Update Account " +
                        " set DeleteFlag = " + (account.DeleteFlag == true ? 1 : 0) +
                        ", currentbalance = " + account.CurrentBalance +
                        //", accountnumber = " + account.LastFourDigits +
                        " where id = " + account.AccountId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }

        public BaseResponse UpdateBucket(Bucket bucket)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "Update Bucket" +
                        " set DeleteFlag = " + bucket.DeleteFlag +
                        ", targetamount = " + bucket.TargetAmount +
                        ", description = " + bucket.Description +
                        ", type = " + bucket.Type +
                        ", balance = " + bucket.Balance +
                        ", startdate = " + bucket.StartDate +
                        ", enddate = " + bucket.EndDate +                    
                        " where id = " + bucket.BucketId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }

        public BaseResponse UpdateTransaction(Transaction transaction)
        {
            var response = new BaseResponse();
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();
                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "Update Trans" +
                         " set DeleteFlag = " + transaction.DeleteFlag +
                         ", description = " + transaction.Description +
                         ", amount = " + transaction.Amount +
                         ", datetime = " + transaction.DateTime.ToString("yyyy/MM/dd hh:mm") +
                         //", time = " + transaction.DateTime.TimeOfDay +
                         ", type = " + transaction.Type +
                         ", bucketid = " + transaction.BucketId +
                         " where id = " + transaction.TransactionId;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                }
            }
            response.IsSuccess = true;
            return response;
        }
    }
}
