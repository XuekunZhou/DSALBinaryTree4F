public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? Left { get; set; }      
    public TreeNode? Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
    }

    public void Get()
    {

    }

    // Checks if the value is equal to the value of the node
    // Depending on if its bigger or smaller it recursively calls the function again on either right or left
    // When it finds the value it returns a response with a message and the node holding the value
    // When it reaches a deadend or null means that the value is not in the tree and so returns a message and null
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


    // Compares the value to the values of the node 
    // If the value is smaller it needs to go left and if its bigger it goes right
    // It keeps looking until it finds a null, a place to put the value. 
    // If the value already exist or it has been placed it sends a message and the node with the location
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

            Left = new TreeNode(value);
            return new Response("Added", Left);
        }

        if (Right != null)
        {
            return Right.Add(value);
        }

        Right = new TreeNode(value);
        return new Response("Added", Right);
    }


    // Depricated?
    public Response Remove(int value)
    {
        Console.WriteLine("Remove() has been called");
        if (value == Value)
        {
            return new Response("Cant remove root node", null);
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

        return new Response("Not found", null);
    }

    
    // Looks for the target value while storing the parent node and the direction it came from
    // When the value has been found it checks how many children this node has
    // Depending on that it calls a function that removes the node
    // Returns a message and null
    public Response Remove(int value, TreeNode parent, bool isLeft)
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

    // If the node has no children it will remove the node by using the parent node reference to itself
    // Returns a message and null
    private Response RemoveNoChildren(TreeNode parent, bool isLeft)
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

    // If the node has a single child it will check which direction it child goes and changes the reference in its parent node to its child node
    // Returns a message and null
    private Response RemoveOneChild(TreeNode parent, bool isLeft)
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

    // If the node has two children it will grab the lowest value node of its right branch to be inserted in the tree on its own place.
    // The left and right branches will be added to this new root node and the reference to this node needs to be removed from its old parent
    // Returns a message and null 
    private Response RemoveTwoChildren(TreeNode parent, bool isLeft)
    {
        if (Right != null && Left != null)
        {
            var newRoot = Right.Min(this)[0];
            var oldParent = Right.Min(this)[1];

            newRoot.Left = this.Left;

            if (newRoot.Value != this.Right.Value)
            {
                newRoot.Right = this.Right;
            }
            oldParent.Left = null;

            if (isLeft)
            {
                parent.Left = newRoot;
            }
            else 
            {
                parent.Right = newRoot;
            }
        }

        return new Response("Removed", null);
    }


    // Count how many children a node has
    // Returns an int
    public int CountChildren()
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

    // Finds the lowest value by going left until it hits a null
    // Returns a TreeNode
    public TreeNode Min()
    {
        if (Left != null)
        {
            return Left.Min();
        }

        return this;
    }

    // It works the same as the other Min method but for one application I also need the parent node
    // Returns an array with TreeNodes
    public TreeNode[] Min(TreeNode parent)
    {
        if (Left != null)
        {
            return Left.Min(this);
        }

        TreeNode[] package = {this, parent};
        return package;
    }

}