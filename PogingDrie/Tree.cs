public class Tree<T> where T : IComparable
{
    public TreeNode<T>? Root { get; set; }

    public Tree(T value)
    {
        Root = new TreeNode<T>(value);
    }

    public Tree()
    {
        
    }

    public Response<T> Get(int level, int col)
    {
        if (Root != null)
        {
            return Root.Get(level, col);
        }

        return new Response<T>("No tree", null);
    }   

    public Response<T> Find(T value)
    {
        if (Root != null)
        {
            return Root.Find(value);
        }
        return new Response<T>("No Tree", null);
    }

    public Response<T> Add(T value)
    {
        if (Root != null)
        {
            return Root.Add(value);
        }
        return new Response<T>("No Tree", null);
    }

    private Response<T> RemoveNoChildren()
    {
        if (Root != null)
        {
            Root = null;

            return new Response<T>("Removed", null);
        }
        return new Response<T>("No Tree", null);
    }

    private Response<T> RemoveOneChild()
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
            return new Response<T>("Removed", null);
        }

        return new Response<T>("No Tree", null);
    }

    private Response<T> RemoveTwoChildren()
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
            
            return new Response<T>("Removed", null);
        }
        
        return new Response<T>("No Tree", null);
    }

    public Response<T> Remove(T value)
    {
        if (Root != null)
        {
            if (Root.Value.CompareTo(value) == 0)
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
                return new Response<T>("Removed", Root);
            }

            if (Root.Value.CompareTo(value) > 0)
            {
                return Root.Remove(value, Root, true);
            }
            return Root.Remove(value, Root, false);
        }

        return new Response<T>("No Tree", null);
    }
}