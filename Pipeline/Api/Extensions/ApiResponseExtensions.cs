namespace Api.Extensions;

public static class ApiResponseExtensions
{
    public static IActionResult ToActionResult<T>(this ApiResponse<T> apiResponse) where T : class
    {
        if (apiResponse.IsValid)
        {
            return HandleValidResponses(apiResponse);
        }

        return HandleInvalidResponses(apiResponse);
    }

    private static IActionResult HandleValidResponses<T>(ApiResponse<T> apiResponse) where T : class =>
        apiResponse.HttpStatusCode switch
        {
            HttpStatusCode.OK => Ok(apiResponse.Data!),
            HttpStatusCode.Created => StatusCode((int)HttpStatusCode.Created, apiResponse.Data!),
            HttpStatusCode.NoContent => NoContent(),
            _ => StatusCode((int)HttpStatusCode.InternalServerError, "Erreur inconnnue")
        };

    private static IActionResult HandleInvalidResponses<T>(ApiResponse<T> apiResponse) where T : class =>
        apiResponse.HttpStatusCode switch
        {
            HttpStatusCode.Conflict => Conflict(apiResponse.ErrorMessage),
            HttpStatusCode.NotFound => NotFound(apiResponse.ErrorMessage),
            HttpStatusCode.BadRequest => BadRequest(apiResponse.ErrorMessage),
            _ => StatusCode((int)HttpStatusCode.InternalServerError, "Erreur inconnnue")
        };

    private static OkObjectResult Ok(object value) => new(value);

    private static ObjectResult StatusCode(int statusCode, object value) =>
        new(value)
        {
            StatusCode = statusCode
        };

    private static NoContentResult NoContent() => new();
    private static ConflictObjectResult Conflict(object error) => new(error);
    private static NotFoundObjectResult NotFound(object error) => new(error);
    private static BadRequestObjectResult BadRequest(object error) => new(error);
}
