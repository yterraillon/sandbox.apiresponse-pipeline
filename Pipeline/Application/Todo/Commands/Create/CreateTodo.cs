namespace Application.Todo.Commands.Create;
using Models;

public static class CreateTodo
{
    public record Request(string Name) : IRequest<ApiResponse<string>>;

    public record Response(string Id);

    public class Handler : IRequestHandler<Request, ApiResponse<string>>
    {
        public Task<ApiResponse<string>> Handle(Request request, CancellationToken cancellationToken)
        {
            var todo = Todo.Create(request.Name, isCompleted: false);
            var response = ApiResponse<string>.Success(todo.Id, HttpStatusCode.NoContent);


            return Task.FromResult(response);
        }
    }
}