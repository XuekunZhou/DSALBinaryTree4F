public class Tree
{
    public int Value { get; set; }
    public Tree? Left { get; set; }      
    public Tree? Right { get; set; }

    public Tree(int value)
    {
        Value = value;
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

        else if (Right != null)
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

}