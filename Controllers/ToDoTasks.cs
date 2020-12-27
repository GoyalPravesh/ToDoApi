using System.Collections.Generic;
using todoapi.Controllers;

public class ToDoTasks
{

    public ToDoTasks()
    {
       tasks= new List<ToDoTask>{
                new ToDoTask(){
                    Id=1,
                    Description="Desc1",
                    Status=TaskStatus.Pending
                },
                 new ToDoTask(){
                    Id=2,
                    Description="Desc2",
                    Status=TaskStatus.Pending
                },
                 new ToDoTask(){
                    Id=1,
                    Description="Desc3",
                    Status=TaskStatus.Pending
                }
            };
       
    }
    private readonly List<ToDoTask> tasks;

    public List<ToDoTask> GetAll()
    {
        return tasks;
    }

    
    public ToDoTask Add(ToDoTask task)
    {
        tasks.Add(task);
        return task;
    }
}