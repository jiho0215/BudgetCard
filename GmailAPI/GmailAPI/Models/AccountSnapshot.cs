using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.Models
{
    public class AccountSnapshot
    {
        public int? AccountSnapshotId { get; set; }
        public DateTime DateTime { get; set; }
        public float TotalDeposit { get; set; }
        public float TotalWithdrawal { get; set; }
        public float CurrentBalance { get; set; }
        public int? AccountId { get; set; }
    }
}
