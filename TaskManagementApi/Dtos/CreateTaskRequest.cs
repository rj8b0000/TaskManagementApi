namespace TaskManagementApi.Dtos;

public class CreateTaskResponse
{
    public string TaskName { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
}