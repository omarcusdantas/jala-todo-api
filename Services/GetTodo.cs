using JalaTodoApi.Contracts;
using JalaTodoApi.Models;

namespace JalaTodoApi.Services;

public class GetTodo(ITodoRepository todoRepository) : IGetTodo
{
    private readonly ITodoRepository _repository = todoRepository;

    public Task<Todo> Execute(Guid id)
    {
        return _repository.Get(id);
    }
}
