using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.Models
{
    public class Transaction
    {
        public int? TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public float Amount { get; set; } 
        public string Type { get; set; }
        public string Description { get; set; }
        public int BucketId { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
