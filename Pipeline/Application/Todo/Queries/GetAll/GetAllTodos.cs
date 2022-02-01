namespace Application.Todo.Queries.GetAll;
using Models;

public static class GetAllTodos
{
    public record Request() : IRequest<ApiResponse<IEnumerable<Todo>>>;

    public class Handler : IRequestHandler<Request, ApiResponse<IEnumerable<Todo>>>
    {
        public Task<ApiResponse<IEnumerable<Todo>>> Handle(Request request, CancellationToken cancellationToken)
        {
            var todos = new List<Todo>
            {
                Todo.Create("first todo", true),
                Todo.Create("second todo", true),
                Todo.Create("third", false),
            };

            var response = ApiResponse<IEnumerable<Todo>>.Failure("Could not get any todo", HttpStatusCode.NotFound);
            return Task.FromResult(response);
        }
    }
}

