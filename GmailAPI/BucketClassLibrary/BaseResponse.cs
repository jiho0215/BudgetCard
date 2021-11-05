using System;
using System.Collections.Generic;
using System.Text;

namespace BucketClassLibrary
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
