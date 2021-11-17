using System;
using System.Collections.Generic;

namespace Buckit.Data
{
    public partial class BuckitUser
    {
        public BuckitUser()
        {
            Accounts = new HashSet<Account>();
            BucketTransactions = new HashSet<BucketTransaction>();
        }

        public int BuckitUserId { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DeleteFlag { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<BucketTransaction> BucketTransactions { get; set; }
    }
}
