using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI.Models
{
    public class Account
    {
        public int? AccountId { get; set; }
        public float CurrentBalance { get; set; }
        public string LastFourDigits { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
