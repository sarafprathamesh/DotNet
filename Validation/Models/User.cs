namespace UserClass;

public class User{
    public string userName{get;set;}

    public string passWord{get;set;}

    public User(string username,string password){
        this.userName=username;
        this.passWord=password;
    }
}