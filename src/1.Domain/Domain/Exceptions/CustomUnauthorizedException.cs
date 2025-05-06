namespace Domain.Exceptions;

public class CustomUnauthorizedException : Exception
{
    public CustomUnauthorizedException(string message)
        : base(message) { }
}
