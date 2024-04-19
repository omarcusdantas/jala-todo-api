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
        if (todo.DueDate < DateTime.UtcNow)
        {
            throw new CustomException(HttpStatusCode.UnprocessableEntity, "DueDate is invalid. A Todo can't be created as overdue");
        }

        return _repository.Create(todo);
    }
}
