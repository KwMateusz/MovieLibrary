using System;

namespace MovieLibrary.Core.Exceptions;

public class MovieException : Exception
{
    public MovieException() : base()
    {
    }

    public MovieException(string message) : base(message)
    {
    }

    public MovieException(string message, Exception innerException) : base(message, innerException)
    {
    }
}