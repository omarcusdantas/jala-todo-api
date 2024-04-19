using AutoMapper;
using JalaTodoApi.Contracts;
using JalaTodoApi.Dtos;
using JalaTodoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JalaTodoApi.Controllers;

[ApiController]
[Tags("Todos")]
[Route("api/v1/todos")]
public class TodoController : ControllerBase
{
    [HttpGet]
    [Route("{todoId:guid:required}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Retrieve a todo identified by its id.")]
    public async Task<IActionResult> Get([FromRoute] Guid todoId, [FromServices] IGetTodo getTodo)
    {
        var todo = await getTodo.Execute(todoId);

        return Ok(todo);
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(List<Todo>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Retrieve a list with all todos.")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllTodos getAllTodos)
    {
        var todo = await getAllTodos.Execute();

        return Ok(todo);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [SwaggerOperation(Summary = "Submit a todo.")]
    public async Task<IActionResult> Create([FromBody] CreateTodoDto todo,
        [FromServices] ICreateTodo createTodo, [FromServices] IMapper mapper)
    {
        var mappedTodo = mapper.Map<Todo>(todo);

        var createdTodo = await createTodo.Execute(mappedTodo);

        return CreatedAtAction(nameof(Create),"", createdTodo);
    }

    [HttpPut]
    [Route("{todoId:guid:required}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Update a todo identified by its id.")]
    public async Task<IActionResult> Update([FromRoute] Guid todoId, [FromBody] UpdateTodoDto todo, 
        [FromServices] IUpdateTodo updateTodo, [FromServices] IMapper mapper)
    {
        var mappedTodo = mapper.Map<Todo>(todo);

        var updatedTodo = await updateTodo.Execute(todoId, mappedTodo);

        return Ok(updatedTodo);
    }

    [HttpDelete]
    [Route("{todoId:guid:required}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Delete a todo identified by its id.")]
    public async Task<IActionResult> Delete([FromRoute] Guid todoId, [FromServices] IDeleteTodo deleteTodo)
    {
        await deleteTodo.Execute(todoId);

        return NoContent();
    }

    [HttpPatch]
    [Route("{todoId:guid}/overdue")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Set a todo identified by its id as overdue.")]
    public async Task<IActionResult> SetAsOverdue([FromRoute] Guid todoId, [FromServices] ISetTodoAsOverdue setTodoAsOverdue)
    {
        var todo = await setTodoAsOverdue.Execute(todoId);

        return Ok(todo);
    }
}
