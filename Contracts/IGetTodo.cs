using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface IGetTodo
{
    Task<Todo> Execute(Guid id);
}
