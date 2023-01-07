namespace Serialization;
using UserClass;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; 
using UserCredential;


[Serializable]
public static class Serialize
{
    private static string userFileNameJSON = @"D:\Github data\Prathamesh Git\DotNet\Validation\wwwroot\database\User.json";
    private static string userJsonString = File.ReadAllText(userFileNameJSON);
    private static string credentialJSON = @"D:\Github data\Prathamesh Git\DotNet\Validation\wwwroot\database\Credential.json";
    


    public static Boolean ValidateUser(string username, string password)
    {
        string credentialJsonString = File.ReadAllText(credentialJSON);
        // return credentialJsonString;
var options = new JsonSerializerOptions { IncludeFields = true, PropertyNameCaseInsensitive = true };
        List<Credential> userList= System.Text.Json.JsonSerializer.Deserialize<List<Credential>>(credentialJsonString,options);
        foreach (Credential user1 in userList)
        {
            Console.WriteLine("USER ID IN VALIDATOR-----" + user1.UserID);
            Console.WriteLine("USER PASSWORD IN VALIDATOR-----" + user1.PassWD);
            if (user1.UserID == username && user1.PassWD == password)
            {
                Console.WriteLine("ID---------------------------" + user1.UserID);
                Console.WriteLine("Password---------------------------" + user1.PassWD);
                return true;
            }
        }
        return false;
    }
    

    public static bool InsertCredential(string username, string password)
    {

        string credentialJsonString = File.ReadAllText(credentialJSON);
        List<Credential> credentialList = JsonSerializer.Deserialize<List<Credential>>(credentialJsonString);

        foreach (Credential user2 in credentialList)
        {
            if (user2.UserID == username)
            {
                return false;
            }
        }
        Credential data=new Credential (username, password);
        credentialList.Add(data);
        var options = new JsonSerializerOptions { IncludeFields = true };
        var credential = JsonSerializer.Serialize<List<Credential>>(credentialList, options);
        File.WriteAllText(credentialJSON, credential);
        return true;
    }

    public static bool InsertUserDetails(string username, string firstname, string lastname, string location, string phonenumber)
    {
        return false;
    }
}