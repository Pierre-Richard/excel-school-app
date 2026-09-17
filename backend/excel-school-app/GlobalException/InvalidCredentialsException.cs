using System;

namespace excel_school_app.GlobalException
{
    public class  InvalidCredentialsException : Exception
    {
         private const string DefaultMessage = "Email ou mot de passe incorrect.";

    public InvalidCredentialsException()
        : base(DefaultMessage)
    {
    }

    public InvalidCredentialsException(string message)
        : base(message)
    {
    }

    public InvalidCredentialsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
    }
}
