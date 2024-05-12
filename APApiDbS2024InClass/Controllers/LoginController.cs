using APApiDbS2024InClass.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace APApiDbS2024InClass.Controllers;
[Route("api/Login")]
public class LoginController : Controller
{
    // In real world application, these would be saved in a database
    private Dictionary<string, string> AllowedCredentials = new Dictionary<string, string>() {
  { "Harry", "Passcode1!" }, { "Sabrina", "Passcode2!" }, { "Johnny", "Passcode3!" }, { "Mette", "Passcode4!" }, { "Wu", "Passcode5!" }, { "Roseanne", "Passcode6!" }, { "Joo-hyuk", "Passcode7!" }, { "Batman", "Passcode7!" }, { "Loki", "Passcode8!" },{ "Scott", "Passcode9!" },
    };

    //private const string USERNAME = "john.doe";
    //private const string PASSWORD = "VerySecret!";
    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login([FromBody] Login credentials)
    {
        if (AllowedCredentials.ContainsKey(credentials.Username) && AllowedCredentials[credentials.Username] == credentials.Password)
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