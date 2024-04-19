namespace JalaTodoApi.Dtos;

public record UpdateTodoDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public bool Overdue {  get; set; }

    public DateTime DueDate { get; set; }
}
