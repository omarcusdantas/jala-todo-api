using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface IUpdateTodo
{
    Task<Todo> Execute(Guid id, Todo todo);
}
