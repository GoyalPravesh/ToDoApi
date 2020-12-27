using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace todoapi.Controllers
{
    [Route("[controller]")]
    public class AuthenticationController : Controller{
        private readonly UsernameAndPasswords _logindetail;
         private readonly List<UsernameAndPassword> logins;
         private readonly AppSettings _appSettings;
        public AuthenticationController(UsernameAndPasswords logindetail, IOptions<AppSettings> appsettings){
             logins=logindetail.GetAll();
            _logindetail=logindetail;

            _appSettings=appsettings.Value;
        }


         [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsernameAndPassword creds )
        {
        var response = logins.SingleOrDefault(m => m.UserName==creds.UserName && m.Password == creds.Password);
        if (response == null)
                return null;
        else
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key=Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor{
                        Subject= new System.Security.Claims.ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.Name, creds.UserName.ToString()),
                            new Claim(ClaimTypes.Version, "v1")
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tok=tokenHandler.CreateToken(tokenDescriptor) ;
                    User user =new User();
                    user.UserName= creds.UserName;
                    user.token= tokenHandler.WriteToken(tok);
                //return  Ok(new {message ="Successful login!!"+ user } );
                return Ok(user.token);
                }
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] UsernameAndPassword creds ){
            // _logindetail.Add(creds);
            return Ok();
        }
    }
}
 public class UsernameAndPassword
    {
        public string UserName{get;set;}
        public string Password{get;set;}
    }
    public class User{
        public string UserName{get;set;}
        public string token{get; set;}
    }