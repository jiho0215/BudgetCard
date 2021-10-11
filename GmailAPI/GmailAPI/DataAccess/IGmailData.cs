using GmailAPI.APIHelper;
using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.DataAccess
{
    public interface IGmailData
    {
        List<Gmail> GetUnreadDailySummaryListFromGmail(string HostEmailAddress);
    }
}
