public class Response<T> where T : IComparable
{
    public string Message { get; set; }
    public TreeNode<T> Result { get; set; }

    public Response(string message, TreeNode<T> result)
    {
        Message = message;
        Result = result;
    }
}