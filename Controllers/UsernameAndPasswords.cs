using System.Collections.Generic;
using todoapi.Controllers;

public class UsernameAndPasswords
{

    public UsernameAndPasswords()
    {
       Login= new List<UsernameAndPassword>{
                new UsernameAndPassword(){
                    UserName= "Pravesh",
                    Password="12345"
                },
                 new UsernameAndPassword(){
                    UserName= "sajid",
                    Password="12345"
                },
                 new UsernameAndPassword(){
                    UserName= "vedant",
                    Password="12345"
                }
            };
       
    }
    private readonly List<UsernameAndPassword> Login;

    public List<UsernameAndPassword> GetAll()
    {
        return Login;
    }

    
    // public UsernameAndPassword Add(UsernameAndPassword login)
    // {
    //     Login.Add(login);
    //     return login;
    // }
    
}