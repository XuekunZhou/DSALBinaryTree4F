public class Response
{
    public string Message { get; set; }
    public TreeNode? Result { get; set; }

    public Response(string message, TreeNode? result)
    {
        Message = message;
        Result = result;
    }
}