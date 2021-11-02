using System;
using System.Collections.Generic;
using System.Text;

namespace BuckitClassLibrary
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
