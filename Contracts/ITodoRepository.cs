using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAll();

    Task<Todo> Get(Guid id);

    Task<Todo> Create(Todo todo);

    Task<Todo> Update(Guid id, Todo todo);

    Task<bool> Delete(Guid id);
}
