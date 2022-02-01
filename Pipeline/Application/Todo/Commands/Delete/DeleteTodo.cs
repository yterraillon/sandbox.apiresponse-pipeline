namespace Application.Todo.Commands.Delete;

public static class DeleteTodo
{
    public record Request(string Id) : IRequest<ApiResponse<Response>>;

    // Note : pas possible de renvoyer un bool directement
    public record Response(bool IsSuccess);

    public class Handler : IRequestHandler<Request, ApiResponse<Response>>
    {
        public Task<ApiResponse<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var response = ApiResponse<Response>.Success(new Response(true));
            return Task.FromResult(response);
        }
    }
}
