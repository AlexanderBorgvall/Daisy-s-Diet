using System.Diagnostics;
using System.Text;
using APApiDbS2024InClass.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Net;
namespace APApiDbS2024InClass.Middleware;
public class BasicAuthenticationMiddleware
{
    // Ideally, we would want to verfy them against a database
    //private const string USERNAME = "john.doe";
    //private const string PASSWORD = "VerySecret!";
    private Dictionary<string, string> AllowedCredentials = new Dictionary<string, string>() {
  { "Harry", "Passcode1!" }, { "Sabrina", "Passcode2!" }, { "Johnny", "Passcode3!" }, { "Mette", "Passcode4!" }, { "Wu", "Passcode5!" }, { "Roseanne", "Passcode6!" }, { "Joo-hyuk", "Passcode7!" }, { "Batman", "Passcode7!" }, { "Loki", "Passcode8!" },{ "Scott", "Passcode9!" },
    };

    private readonly RequestDelegate _next;
    public BasicAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Bypass authentication for [AllowAnonymous]
        if (context.GetEndpoint()?.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            await _next(context);
            return;
        }
        // 1. Try to retrieve the Request Header containing our secret value
        string authHeader = context.Request.Headers["Authorization"];
        // 2. If not found, then return with Unauthrozied response
        if (authHeader == null)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization Header value not provided");
            return;
        }
        // 3. Extract the username and password from the value by splitting it on space,
        // as the value looks something like 'Basic am9obi5kb2U6VmVyeVNlY3JldCE='
        var auth = authHeader.Split(new[] { ' ' })[1];
        // 4. Convert it form Base64 encoded text, back to normal text
        var usernameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
        // 5. Extract username and password, which are separated by a semicolon
        var username = usernameAndPassword.Split(new[] { ':' })[0];
        var password = usernameAndPassword.Split(new[] { ':' })[1];
        // 6. Check if both username and password are correct
        if (AllowedCredentials.ContainsKey(username) && AllowedCredentials[username] == password)
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












































/*public async Task InvokeAsync(HttpContext context)
{
    string requestBody;
    using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
    {
        requestBody = await reader.ReadToEndAsync();
    }

    // Deserialize the request body JSON to a model
    var credentials = JsonConvert.DeserializeObject<Login>(requestBody);
    if (credentials == null)
    { 
    context.Response.StatusCode = 401;
    await context.Response.WriteAsync("Incorrect credentials provided");
    return;
    }
    // Extract the username and password from the model
    string username = credentials.Username;
    string password = credentials.Password;
    // 1. Try to retrieve the Request Header containing our secret value
    Debug.WriteLine(context.Request);
    context.Items["Credentials"] = credentials;
    if (AllowedCredentials.ContainsKey(credentials.Username) && AllowedCredentials[credentials.Username] == credentials.Password)
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
}*/
