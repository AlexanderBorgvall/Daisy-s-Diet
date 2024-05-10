using System.Text.Json.Serialization;
namespace APApiDbS2024InClass.Model;
public class Login
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}