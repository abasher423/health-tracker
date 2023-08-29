using System.Net;

namespace Common.Exceptions;

public static class ExceptionStatusCodes
{
    private static Dictionary<Type, HttpStatusCode> exceptionStatuscodes = new Dictionary<Type, HttpStatusCode>
    {
        { typeof(ProfileArgumentException), HttpStatusCode.BadRequest }
    };

    public static HttpStatusCode GetExceptionStatusCode(Exception exception)
    {
        bool exceptionFound = exceptionStatuscodes.TryGetValue(exception.GetType(), out var statusCode);
        return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
    }
}