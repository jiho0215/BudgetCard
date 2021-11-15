using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Buckit.Model
{
    public class BuckitUser : IdentityUser
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
