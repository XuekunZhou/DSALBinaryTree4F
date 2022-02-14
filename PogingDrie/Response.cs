public class Response
{
    public string Message { get; set; }
    public Tree? Result { get; set; }

    public Response(string message, Tree? result)
    {
        Message = message;
        Result = result;
    }
}