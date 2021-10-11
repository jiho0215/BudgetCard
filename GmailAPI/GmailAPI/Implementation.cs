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

        public void UpdateUnreadDailySummary(string hostEmailAddress, GmailConverter gmailConverter, IGmailData gmailData)
        {
            //Properties

            //Get data from Gmail
            var gmailList = gmailData.GetUnreadDailySummaryListFromGmail(hostEmailAddress);
            var htmlList = gmailList.Select(x => x.Body).ToList();
            var dailySummaryList = gmailConverter.ConvertToDailySummaryList(htmlList);

            //Update to database
        }
    }
}
