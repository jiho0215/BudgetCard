using System;
using System.Collections.Generic;

namespace Buckit.Data
{
    public partial class Bucket
    {
        public Bucket()
        {
            BucketTransactions = new HashSet<BucketTransaction>();
        }

        public int BucketId { get; set; }
        public decimal TargetAmount { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Balance { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? DeleteFlag { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual ICollection<BucketTransaction> BucketTransactions { get; set; }
    }
}
