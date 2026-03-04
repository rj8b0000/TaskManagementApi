using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Dtos;
using TaskManagementApi.Services;
namespace TaskManagementApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class TaskApiController(ITaskApiService service) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<ActionResult<List<TaskResponse>>> GetAllTasks() => Ok(await service.GetAllTasksAsync());

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> AddTask(CreateTaskRequest taskRequest)
    {
        var createdTask = await service.AddTasksAsync(taskRequest);
        return CreatedAtAction(nameof(GetAllTasks), new { id = createdTask.Id }, createdTask);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskResponse>> UpdateTask(int id, UpdateTaskRequest taskRequest)
    {
        var updatedTask = await service.UpdateTaskStatusAsync(id, taskRequest);
        return updatedTask ? Ok("Task Updated successfully") : NotFound("No task found with id: " + id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskResponse>> DeleteTask(int id)
    {
        var deleteTask = await service.DeleteTaskAsync(id);
        return deleteTask ? Ok(deleteTask) : NotFound("No task found with id: " + id);
    }

}