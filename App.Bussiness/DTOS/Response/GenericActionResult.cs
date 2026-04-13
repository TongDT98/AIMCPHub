using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.DTOS.Response
{
    public class GenericActionResult
    {
        public int HttpStatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public object Data { get; set; }
        public int ObjCount { get; set; }
        public double RequestTime { get; set; }
        public int? CurrentPage { get; set; }
        public int? TotalPage { get; set; }
        public int? PerPage { get; set; }
        public bool? LastPage { get; set; }
        public GenericActionResult()
        {
            Success = true;
            HttpStatusCode = 200;
        }
        public GenericActionResult(int objCount, object data)
        {
            Success = true;
            HttpStatusCode = 200;
            ObjCount = objCount;
            Data = data;
        }
    }
}
