﻿namespace Domain.Exceptions;

public class CustomNotFoundException : Exception
{
    public CustomNotFoundException(string message)
        : base(message) { }
}
