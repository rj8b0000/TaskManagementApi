using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.Dtos;
using TaskManagementApi.Models;

namespace TaskManagementApi.Services;

public class TaskApiService(AppDbContext context): ITaskApiService
{
    public async Task<List<TaskResponse>> GetAllTasksAsync() => await context.Tasks.Select(t => new TaskResponse
    {
        Id = t.Id,
        TaskName = t.TaskName,
        Completed = t.Completed,
        CreatedAt = t.CreatedAt,
    }).ToListAsync();

    public async Task<TaskResponse> AddTasksAsync(CreateTaskRequest taskRequest)
    {
        var newTask = new Tasks
        {
            TaskName = taskRequest.TaskName,
            Completed = false,
            CreatedAt = DateTime.UtcNow,
        };
        context.Tasks.Add(newTask);
        await context.SaveChangesAsync();

        return new TaskResponse
        {
            TaskName = newTask.TaskName,
            Completed = newTask.Completed,
            CreatedAt = newTask.CreatedAt,
        };
    }
    
    public async Task<bool> UpdateTaskStatusAsync(int id,  UpdateTaskRequest taskRequest)
    {
        var existingTask = await context.Tasks.FindAsync(id);
        if (existingTask is null) return false;
        existingTask.Completed = taskRequest.TaskStatus;
        
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var selectedTask = await context.Tasks.FindAsync(id);
        if (selectedTask is null) return false;
        context.Tasks.Remove(selectedTask);
        await context.SaveChangesAsync();
        return true;
    }
}