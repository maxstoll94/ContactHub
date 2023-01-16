using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactHub.Domain.ErrorHandling
{
    public class CustomError
    {
        public CustomError(string code, string message, string target)
        {
            Code = code;
            Message = message;
            Target = target;
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }

        public override string ToString()
        {
            return $"Code: {Code}; Message: {Message}; Target: {Target}";
        }
    }
}
