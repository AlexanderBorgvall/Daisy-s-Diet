using System.Diagnostics;
using System.Text;
using APApiDbS2024InClass.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
namespace APApiDbS2024InClass.Middleware;
public class BasicAuthenticationMiddleware
{
    // Ideally, we would want to verfy them against a database
    private const string USERNAME = "john.doe";
    private const string PASSWORD = "VerySecret!";
    private readonly RequestDelegate _next;
    public BasicAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }
  public async Task InvokeAsync(HttpContext context)
    {
        string requestBody;
        using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
        {
            requestBody = await reader.ReadToEndAsync();
        }

        // Deserialize the request body JSON to a model
        var credentials = JsonConvert.DeserializeObject<Login>(requestBody);

        // Extract the username and password from the model
        string username = credentials.Username;
        string password = credentials.Password;
        // 1. Try to retrieve the Request Header containing our secret value
        Debug.WriteLine(context.Request);
        context.Items["Credentials"] = credentials;
        if (username == USERNAME && password == PASSWORD)
        {
            await _next(context);
        }
        else
        {
            // If not, then send Unauthorized response
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Incorrect credentials provided");
            return;
        }
    }
}
public static class BasicAuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseBasicAuthenticationMiddleware(this
    IApplicationBuilder builder)
    {
        return builder.UseMiddleware<BasicAuthenticationMiddleware>();
    }
}
