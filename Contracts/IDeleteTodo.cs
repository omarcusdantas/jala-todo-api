using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface IDeleteTodo
{
    Task<bool> Execute(Guid id);
}
