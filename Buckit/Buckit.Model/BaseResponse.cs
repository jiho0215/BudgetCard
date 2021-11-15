using System;
using System.Collections.Generic;
using System.Text;

namespace Buckit.Model
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}