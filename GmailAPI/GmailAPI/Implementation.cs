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


        }
        public void AddDailySummaryList(List<DailySummary> dailySummaries)
        {
            if (dailySummaries == null || dailySummaries.Count == 0)
                return;

            dailySummaries.ForEach(dailySummary =>
            {
                AddDailySummary(dailySummary);
            });
        }
        public void AddDailySummary(DailySummary dailySummary)
        {
            //account
            UpsertAccount(dailySummary);
            //add transactions

        }
        public void UpsertAccount(DailySummary dailySummary)
        {
            var account = new Account()
            {
                AccountNumber = dailySummary.EndingDigits,
                CurrentBalance = dailySummary.EndOfDayBalance
            };
            var existingAcount = bucketData.GetAccountByAccountNumber(account);
        }
    }
}
