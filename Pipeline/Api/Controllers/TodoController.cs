using Application.Todo.Commands.Create;
using Application.Todo.Commands.Delete;
using Application.Todo.Queries.Get;
using Application.Todo.Queries.GetWithException;
using Application.Todo.Queries.GetAll;
using Api.Extensions;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetAllTodos.Request());
        return response.ToActionResult();
    }

    [HttpGet("error")]
    public async Task<IActionResult> GetAnException()
    {
        var response = await _mediator.Send(new GetTodoWithException.Request());
        return response.ToActionResult();
    }

    [HttpGet("{id}", Name = "Get")]
    public async Task<IActionResult> Get(string id)
    {
        var response = await _mediator.Send(new GetTodo.Request(id));
        return response.ToActionResult();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string value)
    {
        var response = await _mediator.Send(new CreateTodo.Request(value));
        return response.ToActionResult();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _mediator.Send(new DeleteTodo.Request(id));
        return response.ToActionResult();
    }
}

