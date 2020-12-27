using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace todoapi.Controllers
{
   [Authorize (AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)] 
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly List<ToDoTask> tasks;
        private readonly ToDoTasks _taskMngr;
        
        public UsersController(ToDoTasks taskMngr)
        {
            tasks=taskMngr.GetAll();
            _taskMngr=taskMngr;
           
         }

        // To get all users
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(tasks);
        }

        //  to get one user
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            //Linq
            // var t1= tasks.Where(x=>x.Id==id).FirstOrDefault();
            ToDoTask task= null;
            foreach(var t in tasks)
            {
                if(t.Id==id)
                {
                    task= t;
                    break;
                }
            } 
            return Ok(task);
        }

        // to create a new user 
        [HttpPost()]
        public IActionResult Post([FromBody] ToDoTask task)
        {

            _taskMngr.Add(task);
            return Ok();
        }

        // To delete a user

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            var t1= tasks.Where(x=>x.Id==id).FirstOrDefault();
            tasks.Remove(t1);
            
            return Ok();
        }
          }
   
    public class ToDoTask
    {
        public int Id{get;set;}
        public string Description{get;set;}
        public TaskStatus Status{get;set;}
    }
    public enum TaskStatus
    {
        Pending=1,
        Inprogress=2,
        Completed=3
    }
}
    public class AppSettings
    {
        public string Secret { get; set; }
    }
