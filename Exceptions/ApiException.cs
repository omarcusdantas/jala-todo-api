using System.Net;

namespace JalaTodoApi.Exceptions;

public class ApiException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;

    public string Value { get; set; } = message;
}
