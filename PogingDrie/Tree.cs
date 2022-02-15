public class Tree
{
    public int Value { get; set; }
    public Tree? Left { get; set; }      
    public Tree? Right { get; set; }

    public Tree(int value)
    {
        Value = value;
    }

    public void Get()
    {

    }

    public Response Find(int value)
    {
        Console.WriteLine("Find() has been called");

        if (Value == value)
        {
            return new Response("Found", this);
        }
        
        if (value < Value)
        {
            if (Left != null)
            {
                return Left.Find(value);
            }
        }

        if (Right != null)
        {
            return Right.Find(value);
        }

        return new Response("Not found", null);
    }


    public Response Add(int value)
    {
        Console.WriteLine("Add() has been called");

        if (value == Value)
        {
            return new Response("Value already in tree", this);
        }

        if (value < Value)
        {
            if (Left != null)
            {
                return Left.Add(value);
            }

            Left = new Tree(value);
            return new Response("Added", Left);
        }

        if (Right != null)
        {
            return Right.Add(value);
        }

        Right = new Tree(value);
        return new Response("Added", Right);
    }


    public Response Remove(int value)
    {
        Console.WriteLine("Remove() has been called");
        if (value == Value)
        {
            return new Response("Cant remove root node", this);
        }
        if (value < Value)
        {
            if (Left != null)
            {
                return Left.Remove(value, this, true);
            }
        }
        if (Right != null)
        {
            return Right.Remove(value, this, false);
        }

        return new Response("Not found", this);
    }

    
    private Response Remove(int value, Tree parent, bool isLeft)
    {
        Console.WriteLine("Remove() has been called");
        if (value == Value)
        {
            switch (CountChildren())
            {
                case 0:
                    return RemoveNoChildren(parent, isLeft);

                case 1:
                    return RemoveOneChild(parent, isLeft);

                case 2:
                    return RemoveTwoChildren(parent, isLeft);
            }

        }
        if (value < Value)
        {
            if (Left != null)
            {
                return Left.Remove(value, this, true);
            }
        }
        if (Right != null)
        {
            return Right.Remove(value, this, false);
        }

        return new Response("Not found", this);
    }

    private Response RemoveNoChildren(Tree parent, bool isLeft)
    {
        if (isLeft)
        {
            parent.Left = null;
        }
        else
        {
            parent.Right = null;
        }

        return new Response("Removed", parent);
    }

    private Response RemoveOneChild(Tree parent, bool isLeft)
    {
        if (this.Left != null)
        {
            if (isLeft)
            {
                parent.Left = this.Left;
            }
            else
            {
                parent.Right = this.Left;
            }
        }
        else
        {
            if (isLeft)
            {
                parent.Left = this.Right;
            }
            else
            {
                parent.Right = this.Right;
            }
        }

        return new Response("Removed", parent);
    }

    private Response RemoveTwoChildren(Tree parent, bool isLeft)
    {
        var min = Right.Min(this)[0];
        var minParent = Right.Min(this)[1];

        min.Left = this.Left;

        if (min.Value != this.Right.Value)
        {
            min.Right = this.Right;
        }
        minParent.Left = null;

        if (isLeft)
        {
            parent.Left = min;
        }
        else 
        {
            parent.Right = min;
        }

        return new Response("Removed", parent);
    }


    private int CountChildren()
    {
        int count = 0;

        if (Left != null)
        {
            count++;
        }
        if (Right != null)
        {
            count++;
        }

        return count;
    }

    private Tree[] Min(Tree parent)
    {
        if (Left != null)
        {
            return Left.Min(this);
        }

        Tree[] package = {this, parent};
        return package;
    }

}