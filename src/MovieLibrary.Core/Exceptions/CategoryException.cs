using System;

namespace MovieLibrary.Core.Exceptions;

public class CategoryException : Exception
{
    public CategoryException() : base()
    {
    }

    public CategoryException(string message) : base(message)
    {
    }

    public CategoryException(string message, Exception innerException) : base(message, innerException)
    {
    }
}