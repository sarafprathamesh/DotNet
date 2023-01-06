namespace Serialization;
using UserClass;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using UserCredential;


[Serializable]
public class Serialize
{
    private static string userFileNameJSON = @"D:\IACSD PG-DAC Roll No. - 29,60\Assignments\DotNet\Assignments\Validation\wwwroot\database\User.json";
    private static string userJsonString = File.ReadAllText(userFileNameJSON);
    private static string credentialJSON = @"D:\IACSD PG-DAC Roll No. - 29,60\Assignments\DotNet\Assignments\Validation\wwwroot\database\Credential.json";
    private static string credentialJsonString = File.ReadAllText(credentialJSON);
    public static Boolean ValidateUser(string username, string password)
    {

        List<Credential> userList = JsonSerializer.Deserialize<List<Credential>>(credentialJsonString);
        foreach (Credential user1 in userList)
        {
            Console.WriteLine("USER ID IN VALIDATOR-----"+user1.UserID);
            Console.WriteLine("USER PASSWORD IN VALIDATOR-----"+user1.PassWD);
            if (user1.UserID == username && user1.PassWD == password)
            {
                Console.WriteLine("ID---------------------------"+user1.UserID);
                Console.WriteLine("Password---------------------------"+user1.PassWD);
                return true;
            }
        }
        return false;
    }

    public static bool InsertCredential(string username, string password)
    {
        var options = new JsonSerializerOptions { IncludeFields = true };
        List<Credential> credentialList = JsonSerializer.Deserialize<List<Credential>>(credentialJsonString);
       
       foreach (Credential user2 in credentialList)
        {
            if (user2.UserID == username)
            {
                return false;
            }
        }

        credentialList.Add(new Credential(username, password));
        var credential=JsonSerializer.Serialize(credentialList,options);
        File.WriteAllText(credentialJSON, credential);
        return true;
    }

    public static bool InsertUserDetails(string username, string firstname,string lastname, string location, string phonenumber ){
        return false;
    }
}