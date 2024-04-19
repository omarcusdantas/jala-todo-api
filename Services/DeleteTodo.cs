using JalaTodoApi.Contracts;
using JalaTodoApi.Exceptions;
using JalaTodoApi.Models;
using System.Net;

namespace JalaTodoApi.Services;

public class DeleteTodo(ITodoRepository todoRepository) : IDeleteTodo
{
    private readonly ITodoRepository _repository = todoRepository;

    public async Task<bool> Execute(Guid id)
    {   
        var isDeleted = await _repository.Delete(id);

        if (isDeleted == false) throw new CustomException(HttpStatusCode.NotFound, "Todo not found");

        return isDeleted;
    }
}
