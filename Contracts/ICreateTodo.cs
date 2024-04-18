using JalaTodoApi.Models;

namespace JalaTodoApi.Contracts;

public interface ICreateTodo
{
    Task<Todo> Execute(Todo todo);
}
