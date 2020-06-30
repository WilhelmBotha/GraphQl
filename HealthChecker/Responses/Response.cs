using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.GraphQL;

namespace HealthChecker.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<ErrorModel> Errors { get; set; }

        public void OnErrorThrowException()
        {
            if (Errors != null && Errors.Any())
            {
                throw new ApplicationException($"Message: {Errors[0].Message} Code: {Errors[0].Code}");
            }
        }
    }

    public class ServerList
    {
        public List<Server> Servers { get; set; }
    }

    public class ErrorModel
    {
        public string Message { get; set; }

        public string Code { get; set; }
    }

}
