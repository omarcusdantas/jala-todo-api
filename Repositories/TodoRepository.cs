using JalaTodoApi.Contracts;
using JalaTodoApi.Database;
using JalaTodoApi.Models;
using Microsoft.EntityFrameworkCore;

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
        var todo = await _dbContext.Todos.FindAsync(id);

        if (todo is null) return false;

        _dbContext.Remove(todo);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Todo?> Get(Guid id)
    {
        var foundTodo = await _dbContext.Todos.FindAsync(id);

        return foundTodo;
    }

    public async Task<IEnumerable<Todo>> GetAll()
    {
        var todos = await _dbContext.Todos.ToListAsync();

        return todos;
    }

    public async Task<Todo?> Update(Guid id, Todo updateTodo)
    {
        var todo = await _dbContext.Todos.FindAsync(id);
        if (todo is null) return null;

        todo.DueDate = updateTodo.DueDate;
        todo.Overdue = updateTodo.Overdue;
        todo.Description = updateTodo.Description;
        todo.Title = updateTodo.Title;
        todo.UpdatedAt = updateTodo.UpdatedAt;
        
        await _dbContext.SaveChangesAsync();

        return todo;
    }
}
