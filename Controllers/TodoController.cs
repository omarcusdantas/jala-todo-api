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
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] Todo todo, [FromServices] ICreateTodo createTodo)
    {

        var createdTodo = await createTodo.Execute(todo);

        return CreatedAtAction(nameof(Create),"", createdTodo);
    }

    [HttpPut]
    [Route("{todoId:guid:required}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid todoId, [FromBody] Todo todo, [FromServices] IUpdateTodo updateTodo)
    {
        var updatedTodo = await updateTodo.Execute(todoId, todo);

        return Ok(updatedTodo);
    }

    [HttpDelete]
    [Route("{todoId:guid:required}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid todoId, [FromServices] IDeleteTodo deleteTodo)
    {
        await deleteTodo.Execute(todoId);

        return NoContent();
    }

    [HttpPatch]
    [Route("{todoId:guid}/overdue")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SetAsOverdue([FromRoute] Guid todoId, [FromServices] ISetTodoAsOverdue setTodoAsOverdue)
    {
        var todo = await setTodoAsOverdue.Execute(todoId);

        return Ok(todo);
    }
}
