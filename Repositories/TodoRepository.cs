using JalaTodoApi.Contracts;
using JalaTodoApi.Database;
using JalaTodoApi.Exceptions;
using JalaTodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

    public async Task<bool> Delete(Guid id)
    {
        var foundTodo = await _dbContext.Todos.FindAsync(id);

        if (foundTodo is null) return false;

        _dbContext.Remove(foundTodo);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Todo> Get(Guid id)
    {
        var foundTodo = await _dbContext.Todos.FindAsync(id);

        if (foundTodo is null) throw new ApiException(HttpStatusCode.NotFound, "Todo not found");

        return foundTodo;
    }

    public async Task<IEnumerable<Todo>> GetAll()
    {
        var todos = await _dbContext.Todos.ToListAsync();

        return todos;
    }

    public async Task<Todo> Update(Guid id, Todo todo)
    {
        var foundTodo = await _dbContext.Todos.FindAsync(id);

        if (foundTodo is null) throw new ApiException(HttpStatusCode.NotFound, "Todo not found");

        _dbContext.Update(todo);
        await _dbContext.SaveChangesAsync();

        return todo;
    }
}
