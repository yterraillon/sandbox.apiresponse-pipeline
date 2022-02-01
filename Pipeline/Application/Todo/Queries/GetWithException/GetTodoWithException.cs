namespace Application.Todo.Queries.GetWithException;
using Models;

public static class GetTodoWithException
{
    public record Request() : IRequest<ApiResponse<Todo>>;

    public class Handler : IRequestHandler<Request, ApiResponse<Todo>>
    {
        public Task<ApiResponse<Todo>> Handle(Request request, CancellationToken cancellationToken)
        {
           throw new NotImplementedException("meh");
        }
    }
}