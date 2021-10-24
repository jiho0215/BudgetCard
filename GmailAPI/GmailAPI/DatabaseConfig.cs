using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI
{
    public class DatabaseConfig
    {
        public SQLiteConnection mySQLiteConnection;
        public static string DB_FILENAME = @"Data Source=C:\Users\jiho0\Documents\GitHub\BudgetCard\GmailAPI\GmailAPI\BuckitDB.db;";
        //private string connectionString = @"Data Source=.\BucketDB.db;Version=3;";
        public DatabaseConfig()
        {
            mySQLiteConnection = new SQLiteConnection(DB_FILENAME);
            if (!File.Exists("./BuckitDb.db"))
            {
                throw new NotImplementedException();
            }
        }
    }
}
