using System;
using System.Collections.Generic;

#nullable disable

namespace Buckit.Data.Models
{
    public partial class AccountTransaction
    {
        public int AccountTransactionId { get; set; }
        public int? AccountId { get; set; }
        public int? InstituteTransactionId { get; set; }
        public DateTime EventOccuredDatetime { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual Account Account { get; set; }
    }
}
