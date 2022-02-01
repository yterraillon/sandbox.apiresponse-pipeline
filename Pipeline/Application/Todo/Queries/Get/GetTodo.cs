namespace Application.Todo.Queries.Get;
using Models;

public static class GetTodo
{
    public record Request(string Id) : IRequest<ApiResponse<Todo>>;

    public class Handler : IRequestHandler<Request, ApiResponse<Todo>>
    {
        public Task<ApiResponse<Todo>> Handle(Request request, CancellationToken cancellationToken)
        {
            var todo = Todo.Create("Ma todo", true);
            var response = ApiResponse<Todo>.Success(todo);

            return Task.FromResult(response);
        }
    }
}