namespace UserCredential;

public class Credential{
    public string UserID{get;set;}

    public string PassWD{get;set;}

    public Credential(string username,string password){
        this.UserID=username;
        this.PassWD=password;
    }
}