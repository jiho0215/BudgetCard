using System;
using System.Collections.Generic;

#nullable disable

namespace Bucket.Model.Models
{
    public partial class BucketTransaction
    {
        public int BucketTransactionId { get; set; }
        public int? BucketId { get; set; }
        public int? CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDatetime { get; set; }

        public virtual Bucket Bucket { get; set; }
        public virtual BuckitUser CreatedByNavigation { get; set; }
    }
}
