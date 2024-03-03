namespace Common.Exceptions;

public class HealthMetricArgumentException : Exception
{
    public HealthMetricArgumentException()
    {
        
    }

    public HealthMetricArgumentException(string message)
        : base(message)
    {
        
    }
    
    public HealthMetricArgumentException(string message, Exception inner)
        : base(message, inner)
    {
        
    }

    public HealthMetricArgumentException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context)
    {
        
    }
}