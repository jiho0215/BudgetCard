using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailAPI.APIHelper;
using GmailAPI.Converters;
using GmailAPI.DataAccess;
using GmailAPI.Models;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace GmailAPI
{
    public class Implementation
    {
        private string hostEmailAddress { get; set; }
        private GmailConverter gmailConverter { get; set; }
        private IGmailData gmailData { get; set; }
        private IBucketData bucketData { get; set; }

        public Implementation(string hostEmailAddress, GmailConverter gmailConverter, IGmailData gmailData, IBucketData bucketData)
        {
            this.hostEmailAddress = hostEmailAddress;
            this.gmailConverter = gmailConverter;
            this.gmailData = gmailData;
            this.bucketData = bucketData;
        }

        public void UpdateUnreadDailySummary()
        {
            //Properties

            //Get data from Gmail
            var gmailList = gmailData.GetUnreadDailySummaryListFromGmail(hostEmailAddress);
            var htmlList = gmailList.Select(x => x.Body).ToList();
            var dailySummaryList = gmailConverter.ConvertToDailySummaries(htmlList);

            //Update to database
            AddDailySummaryList(dailySummaryList);

            Console.WriteLine("Done");
            Console.ReadLine();

        }
        public void AddDailySummaryList(List<DailySummary> dailySummaries)
        {
            if (dailySummaries == null || dailySummaries.Count == 0)
                return;

            dailySummaries.OrderBy(x => x.Date).ToList().ForEach(dailySummary =>
            {
                AddDailySummary(dailySummary);
            });
        }
        public void AddDailySummary(DailySummary dailySummary)
        {
            //validate account snapshot
            //How to validate? 
            //Implement some validation in the future. Can't stop performing the same amount of transaction happening.

            //account
            UpsertAccount(dailySummary);
            //add transactions
            AddTransactions(dailySummary);
            ////add account snapshot
            //AddAccountSnapshot(dailySummary);
        }
        //public AccountSnapshot GetAccountSnapshot(DailySummary dailySummary)
        //{
        //    return bucketData.GetAccountSnapshot(dailySummary);
        //}
        //public void AddAccountSnapshot(DailySummary dailySummary)
        //{
        //    bucketData.AddAccountSnapshot(dailySummary);
        //}
        public void AddTransactions(DailySummary dailySummary)
        {
            var transactionDate = dailySummary.Date;
            dailySummary.DepositList.ForEach(deposit =>
            {
                AddTransaction(new Transaction()
                {
                    Amount = deposit.Amount,
                    DateTime = transactionDate,
                    Description = deposit.Description,
                    Type = "Deposit"
                });
            });
            dailySummary.WithdrawalList.ForEach(withdrawal =>
            {
                AddTransaction(new Transaction()
                {
                    Amount = withdrawal.Amount,
                    DateTime = transactionDate,
                    Description = withdrawal.Description,
                    Type = "Withdrawal"
                });
            });
        }

        public void AddTransaction(Transaction transaction)
        {
            bucketData.AddTransaction(transaction);
        }

        public void UpsertAccount(DailySummary dailySummary)
        {
            var account = bucketData.GetAccountByAccountNumber(new Account() { LastFourDigits = dailySummary.EndingDigits });
            if (account == null || account.AccountId == null)
            {
                bucketData.AddAccount(
                    new Account()
                    {
                        LastFourDigits = dailySummary.EndingDigits,
                        CurrentBalance = dailySummary.EndOfDayBalance,
                        DateTime = dailySummary.Date
                    });
            }
            else
            {
                account.CurrentBalance = dailySummary.EndOfDayBalance;
                account.LastFourDigits = dailySummary.EndingDigits;
                account.DateTime = dailySummary.Date;
                bucketData.UpdateAccount(account);
            }
        }
    }
}
