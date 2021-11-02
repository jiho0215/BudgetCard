using System;

namespace BuckitClassLibrary
{
    public class Account
    {
        public int? AccountId { get; set; }
        public float CurrentBalance { get; set; }
        public string LastFourDigits { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime DateTime { get; set; }
    }
}
