using JalaTodoApi.Contracts;
using JalaTodoApi.Exceptions;
using JalaTodoApi.Models;
using System.Net;

namespace JalaTodoApi.Services;

public class CreateTodo(ITodoRepository todoRepository) : ICreateTodo
{
    private readonly ITodoRepository _repository = todoRepository;

    public Task<Todo> Execute(Todo todo)
    {
        if (todo.DueDate < todo.CreatedAt && todo.OverDue == false)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Overdue has to be true, since the time to it is over.");
        }

        if (todo.DueDate >= todo.CreatedAt && todo.OverDue == true)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Overdue has to be false, since the time to do it is not over.");
        }

        return _repository.Create(todo);
    }
}
