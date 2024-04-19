namespace JalaTodoApi.Dtos;

public record CreateTodoDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }
}
