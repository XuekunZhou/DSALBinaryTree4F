public class Tree
{
    public TreeNode Root { get; set; }

    public Tree(int value)
    {
        Root = new TreeNode(value);
    }

    public Response Find(int value)
    {
        return Root.Find(value);
    }

    public Response Add(int value)
    {
        return Root.Add(value);
    }

    public Response Remove(int value)
    {
        if (value == Root.Value)
        {
            switch (Root.CountChildren())
            {
                case 0:
                    Root = null;
                    break;
                
                case 1:
                    if (Root.Left != null)
                    {
                        Root = Root.Left;
                    }
                    else 
                    {
                        Root = Root.Right;
                    }
                    break;
                
                case 2:
                    var left = Root.Left;
                    var right = Root.Right;
                    var newRoot = Root.Right.Min();
                    newRoot.Left = left;
                    newRoot.Right = right;

                    Root.Remove(newRoot.Value);
                    Root = newRoot;
                    break;
            }
            return new Response("Removed", Root);
        }

        if (value < Root.Value)
        {
            return Root.Remove(value, Root, true);
        }
        return Root.Remove(value, Root, false);
    }
}