using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public enum StatusCode
    {
        SUCCESS,
        FAILURE
    }
    public class StatusObject
    {
        public StatusCode Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }
        public dynamic UDDynamic { get; set; }
        public StatusObject()
        {
            this.Status = StatusCode.SUCCESS;
        }
        public StatusObject(Exception e, string ErrorCode)
        {
            this.Status = StatusCode.FAILURE;
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = e.Message;
            this.ErrorStackTrace = e.ToString();
        }
    }
}
