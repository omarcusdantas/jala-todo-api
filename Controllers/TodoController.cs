using JalaTodoApi.Contracts;
using JalaTodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JalaTodoApi.Controllers;

[ApiController]
[Tags("Todo")]
[Route("api/v1/todos")]
public class TodoController : ControllerBase
{
    [HttpGet]
    [Route("{todoId:guid:required}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid todoId, [FromServices] IGetTodo getTodo)
    {
        var todo = await getTodo.Execute(todoId);

        return Ok(todo);
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(List<Todo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllTodos getAllTodos)
    {
        var todo = await getAllTodos.Execute();

        return Ok(todo);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Todo todo, [FromServices] ICreateTodo createTodo)
    {

        var createdTodo = await createTodo.Execute(todo);

        return CreatedAtAction(nameof(Create),"", createdTodo);
    }
}
