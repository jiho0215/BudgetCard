using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.Models
{
    public class Bucket
    {
        public int? BucketId { get; set; }
        public float TargetAmount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
