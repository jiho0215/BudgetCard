using System;
using System.Collections.Generic;
using System.Text;

namespace Buckit.Model
{
    public class Account
    {
        public int? AccountId { get; set; }
        public int? BuckitUserId { get; set; }
        public float CurrentBalance { get; set; }
        public string? LastFourDigits { get; set; }
        public string? InstitutionName { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}