using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.Models;

public class Tasks
{
    [Key]
    public int Id { get; set; }
    public string TaskName { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
}