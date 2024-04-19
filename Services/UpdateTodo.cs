using JalaTodoApi.Contracts;
using JalaTodoApi.Exceptions;
using JalaTodoApi.Models;
using System.Net;

namespace JalaTodoApi.Services;

public class UpdateTodo(ITodoRepository todoRepository) : IUpdateTodo
{
    private readonly ITodoRepository _repository = todoRepository;

    public async Task<Todo> Execute(Guid id, Todo todo)
    {
        var foundTodo = await _repository.Get(id);

        if (foundTodo is null) throw new CustomException(HttpStatusCode.NotFound, "Todo not found");

        if (todo.DueDate < DateTime.UtcNow && todo.OverDue == false)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Overdue has to be true, since the time to do it's over");
        }

        if (todo.DueDate >= DateTime.UtcNow && todo.OverDue == true)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Overdue has to be false, since the time to do it is not over");
        }

        return await _repository.Update(todo);
    }
}
