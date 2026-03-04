namespace TaskManagementApi.Dtos;

public class TaskResponse
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
}