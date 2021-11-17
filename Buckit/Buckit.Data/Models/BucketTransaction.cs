using System;
using System.Collections.Generic;

namespace Buckit.Data
{
    public partial class BucketTransaction
    {
        public int BucketTransactionId { get; set; }
        public int? BucketId { get; set; }
        public int? CreatedBy { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? CreateDatetime { get; set; }

        public virtual Bucket? Bucket { get; set; }
        public virtual BuckitUser? CreatedByNavigation { get; set; }
    }
}
