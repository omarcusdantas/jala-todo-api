using JalaTodoApi.Contracts;
using JalaTodoApi.Exceptions;
using JalaTodoApi.Models;
using System.Net;

namespace JalaTodoApi.Services;

public class SetTodoAsOverdue(ITodoRepository todoRepository) : ISetTodoAsOverdue
{
    private readonly ITodoRepository _repository = todoRepository;

    public async Task<Todo> Execute(Guid id)
    {
        var foundTodo = await _repository.Get(id);

        if (foundTodo is null) throw new CustomException(HttpStatusCode.NotFound, "Todo not found");

        if (foundTodo.OverDue == true) throw new CustomException(HttpStatusCode.Conflict, "Todo is already overdue");

        if (foundTodo.DueDate > DateTime.Now)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Todo is not overdue yet");
        }

        return await _repository.Update(foundTodo);
    }
}
