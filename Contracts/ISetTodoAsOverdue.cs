using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface ISetTodoAsOverdue
{
    Task<Todo?> Execute(Guid id);
}
