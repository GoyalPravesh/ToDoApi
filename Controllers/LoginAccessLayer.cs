using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient; 
using System.Linq;  
using System.Threading.Tasks; 
public class LoginAccessLayer{
   public LoginAccessLayer(){
    
       string constr="server=.;database=todo;user id=root;word=Pravesh@03;Integrated Security=SSPI;Persist Security Info=False;";
       

       public IEnumerable<UsernameAndPassword> signUp(UsernameAndPassword creds){
           using (SqlConnection con = new SqlConnection(constr));
           SqlCommand cmd= new SqlCommand("spAddEmployee", con);
           cmd.CommandType = CommandType.StoredProcedure; 
    }
}
}
