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
    class Program
    {
        static void Main(string[] args)
        {
            var implementation = new Implementation();
            var gmailConverter = new GmailConverter();
            var hostEmailAddress = Convert.ToString(ConfigurationManager.AppSettings["HostAddress"]);
            //var gmailData = new GmailData();
            var gmailData = new GmailDataMock();
            implementation.UpdateUnreadDailySummary(hostEmailAddress, gmailConverter, gmailData);
        }
    }
}
