using APApiDbS2024InClass.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace APApiDbS2024InClass.Controllers;
[Route("api/Login")]
public class LoginController : Controller
{
    // In real world application, these would be saved in a database
    private const string USERNAME = "john.doe";
    private const string PASSWORD = "VerySecret!";
    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login()
    {
        var credentials = HttpContext.Items["Credentials"] as Login;
        if (credentials.Username == USERNAME && credentials.Password == PASSWORD)
        {
            // 1. Concatenate username and password with a semicolon
            var text = $"{credentials.Username}:{credentials.Password}";
            // 2. Base64encode the above
            var bytes = System.Text.Encoding.Default.GetBytes(text);
            var encodedCredentials = Convert.ToBase64String(bytes);
            // 3. Prefix with Basic
            var headerValue = $"Basic {encodedCredentials}";
            return Ok(new { headerValue = headerValue });
        }
        else
        {
            return Unauthorized();
        }
    }
}