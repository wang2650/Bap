using System;
using System.Collections.Generic;
using System.Text;

namespace Common.QrCoder
{
    public class QrResult
    {

        public bool IsSuccess { get; set; } = true;


        public string ReturnMessage { get; set; } = string.Empty;

        public byte[] ReturnData { get; set; }



    }
}
