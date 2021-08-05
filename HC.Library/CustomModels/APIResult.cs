using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Library.CustomModels
{
    /// <summary>
    /// Generic class for return API Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public APIResult() {
            Success = false;
        }
    }
}
