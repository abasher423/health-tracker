namespace Common.Exceptions;

public class HealthDataEntryArgumentException : Exception
{
    public HealthDataEntryArgumentException()
    {
        
    }

    public HealthDataEntryArgumentException(string message)
        : base(message)
    {
        
    }

    public HealthDataEntryArgumentException(string message, Exception inner)
        : base(message, inner)
    {
        
    }
}