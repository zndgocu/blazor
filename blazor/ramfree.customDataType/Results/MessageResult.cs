using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ramfree.customDataType.Results
{
    public class MessageResult
    {
        public MessageResult()
        {
        }

        public MessageResult(bool result)
        {
            Result = result;
        }

        public MessageResult(bool result, string? message) : this(result)
        {
            Message = message;
        }

        public bool Result { get; set; }
        public string? Message { get; set; }
    }
}
