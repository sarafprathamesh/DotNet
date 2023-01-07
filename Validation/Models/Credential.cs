namespace UserCredential;
using System.Text.Json.Serialization;
public class Credential
{
    [JsonInclude]
    public string UserID { get; set; }
    [JsonInclude]
    public string PassWD { get; set; }
    [JsonConstructor]
    public Credential(string username, string password)
    {
        this.UserID = username;
        this.PassWD = password;
    }
}