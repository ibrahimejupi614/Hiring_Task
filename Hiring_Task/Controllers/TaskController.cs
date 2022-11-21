using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<TaskModel>> Get()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }

        [HttpPost("add")]
        public async Task<ActionResult<List<TaskModel>>> AddTask(TaskModel task)
        {

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok("Task successfully created! ");
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<TaskModel>>> UpdateTask(TaskModel task)
        {

            var _task = await _context.Tasks.FindAsync(task.TaskeId);
            if (_task == null)
                return BadRequest("Task not found!");
            _task.Name = task.Name;
            _task.Description = task.Description;
            _task.Status = task.Status;

            await _context.SaveChangesAsync();
            return Ok("Task successfully updated! ");
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<List<TaskModel>>> DeleteTask(int TaskeId)
        {
            var _task = await _context.Tasks.FindAsync(TaskeId);
            if (_task == null)
                return BadRequest("Task not found!");

            _context.Tasks.Remove(_task);
            await _context.SaveChangesAsync();
            return Ok("Task successfully Deleted! ");
        }
    }
}
