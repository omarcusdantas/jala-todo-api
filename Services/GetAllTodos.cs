using JalaTodoApi.Contracts;
using JalaTodoApi.Models;

namespace JalaTodoApi.Services;

public class GetAllTodos(ITodoRepository todoRepository) : IGetAllTodos
{
    private readonly ITodoRepository _repository = todoRepository;

    public Task<IEnumerable<Todo>> Execute()
    {
        return _repository.GetAll();
    }
}
