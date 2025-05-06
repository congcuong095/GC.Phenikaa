namespace Domain.Exceptions;

public class CustomInternalErrorException : Exception
{
    public CustomInternalErrorException(string message)
        : base(message) { }
}

