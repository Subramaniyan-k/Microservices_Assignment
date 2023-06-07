using System.Collections.Generic;

namespace Microservices_Assignment.Models
{
   public class ApiResponse<T>
    {
        public List<T> Response { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }      
      
    }
    public class Response<T>
    {
        public string Status { get; set; }       
        public string StatusCode { get; set; }
        public List<T> Data { get; set; }
    }

}
