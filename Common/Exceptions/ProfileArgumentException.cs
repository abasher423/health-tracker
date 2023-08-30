namespace Common.Exceptions;

public class ProfileArgumentException : Exception
{
    public ProfileArgumentException()
    {
        
    }

    public ProfileArgumentException(string message)
        : base(message)
    {
        
    }

    public ProfileArgumentException(string message, Exception inner)
        : base(message, inner)
    {
        
    }

    public ProfileArgumentException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context)
    {
        
    }
}