using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ramfree.database.QueryManager.Result
{
    public class QueryManagerResult<T> where T : new()
    {
        public List<T> Values { get; set; }
        public int ResultCode { get; set; }
        public string Message { get; set; }

        public QueryManagerResult()
        {
            Values = new List<T>();
            ResultCode = -1;
            Message = "";
        }

        public void SetOk(List<T> ts, int resultCode = 0)
        {
            Values = ts;
            ResultCode = resultCode;
        }
        public void SetFail(string message = "", int resultCode = -1)
        {
            ResultCode = resultCode;
        }
    }
}
