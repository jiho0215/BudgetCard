using System;
using System.Collections.Generic;

#nullable disable

namespace Bucket.Model.Models
{
    public partial class Bucket
    {
        public Bucket()
        {
            BucketTransactions = new HashSet<BucketTransaction>();
        }

        public int BucketId { get; set; }
        public decimal TargetAmount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? DeleteFlag { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public int? BuckitUserId { get; set; }

        public virtual BuckitUser BuckitUser { get; set; }
        public virtual ICollection<BucketTransaction> BucketTransactions { get; set; }
    }
}
