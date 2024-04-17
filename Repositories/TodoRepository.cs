using JalaTodoApi.Contracts;
using JalaTodoApi.Database;
using JalaTodoApi.Models;

namespace JalaTodoApi.Repositories;

public class TodoRepository(TodoDBContext dBContext) : ITodoRepository
{
    private readonly TodoDBContext _dbContext = dBContext;

    public async Task<Todo> Create(Todo todo)
    {
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();

        return todo;
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Todo> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Todo>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Todo> Update(Guid id, Todo todo)
    {
        throw new NotImplementedException();
    }
}
