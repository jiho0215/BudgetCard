using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.Models
{
    public class DailySummary
    {
        public DateTime Date { get; set; }
        public int EndingDigits { get; set; }
        public float EndOfDayBalance { get; set; }
        public float TotalWithdrawls { get; set; }
        public List<Transaction> WithdrawalList { get; set; }
        public float TotalDeposit { get; set; }
        public List<Transaction> DepositList { get; set; }
    }
}
