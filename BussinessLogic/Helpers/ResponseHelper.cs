using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.BussinessLogic.Helpers
{
    public enum ResponseStatus {
        success = 1,
        error=2
    }
    public static class ResponseHelper
    {
       public static ResponseModel CreateCommonSuccessResponse(string message, object data=null)
        {
            return new ResponseModel
            {
                Data = data,
                message = message,
                status = ResponseStatus.success
            };
        }
       public static ResponseModel CreateCommonErrorResponse(string message, object data = null)
        {
            return new ResponseModel
            {
                Data = data,
                message = message,
                status = ResponseStatus.error
            };
        }


        public class ResponseModel
        {
            public Object Data { get; set; }
            public string message { get; set; }
            public ResponseStatus status { get; set; }

        }
    }
}
