namespace Domain.Exceptions;

public class CustomForbiddenException : Exception
{
    public CustomForbiddenException(string message)
        : base(message) { }
}
