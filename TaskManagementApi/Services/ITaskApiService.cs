using TaskManagementApi.Dtos;

namespace TaskManagementApi.Services;

public interface ITaskApiService
{
    Task<List<TaskResponse>> GetAllTasksAsync();
    Task<TaskResponse> AddTasksAsync(CreateTaskRequest taskRequest);

    Task<bool> UpdateTaskStatusAsync(int id, UpdateTaskRequest taskRequest);
    Task<bool> DeleteTaskAsync(int id);
}