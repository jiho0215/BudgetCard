using System;
using System.Collections.Generic;
using System.Text;

namespace Buckit.Model
{
    public class Transaction
    {
        public int? TransactionId { get; set; }
        public int? AccountId { get; set; }
        public DateTime EventOccuredDateTime { get; set; }
        public float Amount { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
