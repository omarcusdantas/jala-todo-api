using JalaTodoApi.Contracts;
using JalaTodoApi.Exceptions;
using JalaTodoApi.Models;
using System.Net;

namespace JalaTodoApi.Services;

public class GetTodo(ITodoRepository todoRepository) : IGetTodo
{
    private readonly ITodoRepository _repository = todoRepository;

    public async Task<Todo> Execute(Guid id)
    {
        var foundTodo = await _repository.Get(id);

        if (foundTodo is null) throw new CustomException(HttpStatusCode.NotFound, "Todo not found");

        return foundTodo;
    }
}
