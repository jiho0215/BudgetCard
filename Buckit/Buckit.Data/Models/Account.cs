using System;
using System.Collections.Generic;

namespace Buckit.Data
{
    public partial class Account
    {
        public Account()
        {
            AccountTransactions = new HashSet<AccountTransaction>();
        }

        public int AccountId { get; set; }
        public int? BuckitUserId { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string InstitutionName { get; set; } = null!;
        public int? DeleteFlag { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual BuckitUser? BuckitUser { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
