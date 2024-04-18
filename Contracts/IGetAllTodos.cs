using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface IGetAllTodos
{
    Task<IEnumerable<Todo>> Execute();
}
