using System;
using System.Collections.Generic;

#nullable disable

namespace Buckit.Model.Models
{
    public partial class BuckitUser
    {
        public BuckitUser()
        {
            Accounts = new HashSet<Account>();
            BucketTransactions = new HashSet<BucketTransaction>();
            Buckets = new HashSet<Bucket>();
        }

        public int BuckitUserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DeleteFlag { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<BucketTransaction> BucketTransactions { get; set; }
        public virtual ICollection<Bucket> Buckets { get; set; }
    }
}
