using System;

namespace excel_school_app.GlobalException
{
    public class EmailAlreadyUsedException : Exception
    {
        private const string DefaultMessage = "Cette email est deja utilisé";

        public EmailAlreadyUsedException() : base(DefaultMessage)
        {

        }

           public EmailAlreadyUsedException(string message): base(message)
        {
            
        }

        public EmailAlreadyUsedException(string message, Exception innerException) : base(message, innerException)
        {
        }
          
    }
}
