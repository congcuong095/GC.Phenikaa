﻿namespace Domain.Exceptions;

public class CustomBadRequestException : Exception
{
    public CustomBadRequestException(string message)
        : base(message) { }
}
