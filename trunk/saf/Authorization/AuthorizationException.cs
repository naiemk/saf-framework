using System;


namespace saf.Authorization
{

    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message)
            : base(message)
        { }
    }
}
