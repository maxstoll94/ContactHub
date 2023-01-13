using Contacter.Domain.ErrorHandling;

namespace Contacter.Domain.Exceptions
{
    public class ContractorException : Exception
    {
        public CustomError Error { get; private set; }

        public ContractorException(string code, string message, string target) 
        {
            Error = new CustomError(code, message, target);
        }
    }
}
