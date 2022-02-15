public class Tree
{
    public TreeNode? Root { get; set; }

    public Tree(int value)
    {
        Root = new TreeNode(value);
    }

    public Response Find(int value)
    {
        if (Root != null)
        {
            return Root.Find(value);
        }
        return new Response("No Tree", null);
    }

    public Response Add(int value)
    {
        if (Root != null)
        {
            return Root.Add(value);
        }
        return new Response("No Tree", null);
    }

    private Response RemoveNoChildren()
    {
        if (Root != null)
        {
            Root = null;

            return new Response("Removed", null);
        }
        return new Response("No Tree", null);
    }

    private Response RemoveOneChild()
    {
        if (Root != null)
        {
            if (Root.Left != null)
            {
                Root = Root.Left;
            }
            else 
            {
                Root = Root.Right;
            }
            return new Response("Removed", null);
        }

        return new Response("No Tree", null);
    }

    private Response RemoveTwoChildren()
    {
        if (Root != null && Root.Left != null && Root.Right != null)
        {
            var left = Root.Left;
            var right = Root.Right;

            var newRoot = right.Min(Root)[0];
            var oldParent = right.Min(Root)[1];

            newRoot.Left = left;
            newRoot.Right = right;

            oldParent.Left = null;
            Root = newRoot;
            
            return new Response("Removed", null);
        }
        
        return new Response("No Tree", null);
    }

    public Response Remove(int value)
    {
        if (Root != null)
        {
            if (value == Root.Value)
            {
                switch (Root.CountChildren())
                {
                    case 0:
                        return RemoveNoChildren();
                    
                    case 1:
                        return RemoveOneChild();
                    
                    case 2:
                        return RemoveTwoChildren();
                        
                }
                return new Response("Removed", Root);
            }

            if (value < Root.Value)
            {
                return Root.Remove(value, Root, true);
            }
            return Root.Remove(value, Root, false);
        }

        return new Response("No Tree", null);
    }
}