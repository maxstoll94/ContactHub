using Contacter.Domain.ErrorHandling;

namespace Contacter.Domain.Exceptions
{
    public class ContactorException : Exception
    {
        public CustomError Error { get; private set; }

        public ContactorException(string code, string message, string target) 
        {
            Error = new CustomError(code, message, target);
        }
    }
}
