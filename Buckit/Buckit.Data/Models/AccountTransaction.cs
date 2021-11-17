using System;
using System.Collections.Generic;

namespace Buckit.Data
{
    public partial class AccountTransaction
    {
        public int AccountTransactionId { get; set; }
        public int? AccountId { get; set; }
        public int? InstituteTransactionId { get; set; }
        public DateTime EventOccuredDatetime { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual Account? Account { get; set; }
    }
}
