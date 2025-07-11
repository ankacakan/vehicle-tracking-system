﻿using Newtonsoft.Json;

namespace VehicleTracking.WebApi.Middleware;
public sealed class ErrorResult : ErrorStatusCode
{
    public string Message { get; set; } = string.Empty;
}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public sealed class ValidationErrorDetails : ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}
