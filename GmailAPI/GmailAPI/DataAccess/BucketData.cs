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

        public BaseResponse GetAccountByAccountNumber(Account account)
        {
            using (SQLiteConnection connection = new SQLiteConnection(myDatabase.mySQLiteConnection))
            {
                connection.Open();

                using (SQLiteCommand selectCMD = connection.CreateCommand())
                {
                    selectCMD.CommandText = "SELECT count(Id) FROM Account where accountnumber =" + account.AccountNumber;
                    selectCMD.CommandType = CommandType.Text;
                    SQLiteDataReader myReader = selectCMD.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            string count = myReader[0].ToString();
                        }
                    }
                }

            }

            throw new NotImplementedException();
        }

        public BaseResponse GetBucket(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse GetTransaction(Account account)
        {
            throw new NotImplementedException();
        }

        public BaseResponse AddAccount(Account account)
        {
            var response = new BaseResponse();


            return response;
        }

        public BaseResponse AddBucket(Account account)
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
