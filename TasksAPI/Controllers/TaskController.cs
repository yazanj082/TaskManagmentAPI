using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TasksAPI.Business.Dtos;
using TasksAPI.Business.Extensions;
using TasksAPI.Business.Services;
using TasksAPI.Extentions;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly private ITaskService _service;
        readonly private IConfiguration _config;
        readonly private ILogger<TaskController> _logger;
        public TaskController(IConfiguration config, ITaskService service, ILogger<TaskController> logger)
        {
            _service = service;
            _config = config;
            _logger = logger;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get(int limit ,int skip)
        {
            try
            {
                if (limit > 20)
                    return BadRequest("maximum limit size is 20");
                var auth = Request.Headers["Authorization"];
                var id = JwtExtention.Decode(auth);
                return Ok(_service.GetAllTasks(id, limit, skip));
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post(TaskDto task)
        {
            try
            {
                var auth = Request.Headers["Authorization"];
                var id = JwtExtention.Decode(auth);
                return Ok(_service.CreateTask(task, id));
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("name conflict");
            }
            catch (InvalidDto ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("time is wrong");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize]
        public IActionResult Put(TaskDto task, int taskId)
        {
            try
            {
                var auth = Request.Headers["Authorization"];
                var id = JwtExtention.Decode(auth);
                return Ok(_service.UpdateTask(task, id,taskId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int taskId)
        {
            try
            {
                var auth = Request.Headers["Authorization"];
                var id = JwtExtention.Decode(auth);
                return Ok(_service.DeleteTask(taskId, id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpPost("BulkCreate")]
        [Authorize]
        public IActionResult BulkCreate(IFormFile file)
        {
            try
            {
                var auth = Request.Headers["Authorization"];
                var id = JwtExtention.Decode(auth);
                return Ok(_service.BulkCreateTasks(file, id));
            }
            catch(InvalidDto ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
