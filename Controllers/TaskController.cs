using ManPowerProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ManPowerProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDBContex _dbcontext;

        public TaskController(ILogger<HomeController> logger, AppDBContex dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            List<dynamic> taskData = new List<dynamic>();
            var records= _dbcontext.tasks.ToList();

            foreach(var record in records)
            {
                taskData.Add(record);
            }

            return View(taskData);
        }
        
        [HttpPost]
        public IActionResult SaveTask([FromBody] Tasks task)
        {
            if (task == null)
                return BadRequest("Task data is missing.");
            
            if(task.task_id == 0)
            {

                _dbcontext.tasks.Add(task);
                _dbcontext.SaveChanges();
            }
            else
            {
                _dbcontext.tasks.Entry(task).State=EntityState.Modified;
                _dbcontext.SaveChanges();
            }
            return Ok(new { message = "Task saved successfully!" });
        }

        [HttpPost]

        public IActionResult DeleteTask([FromBody] int taskId)
        {
            var deleteQuery = _dbcontext.tasks.Where(th => th.task_id == taskId).FirstOrDefault();

            if(deleteQuery != null)
            {
                _dbcontext.tasks.Remove(deleteQuery);
                _dbcontext.SaveChanges();
            }

            return Ok(new { message = "deleted successfully" });
        }

    }
}
