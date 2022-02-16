public class TreeNode<T> where T : IComparable
{
    public T Value { get; set; }
    public TreeNode<T>? Left { get; set; }      
    public TreeNode<T>? Right { get; set; }

    public TreeNode(T value)
    {
        Value = value;
    }

    public Response<T> Get(int level, int col)
    {
        int levelSize = (int) Math.Pow(2, level);

        if (col >= levelSize || col < 0 || level < 0)
        {
            return new Response<T>("Out of bounds", null);
        }

        if (level == 0)
        {
            return new Response<T>("Found", this);
        }

        if (level == 1)
        {
            if (col == 0)
            {
                if (Left != null)
                {
                    return new Response<T>("Found", Left);
                }
                
                return new Response<T>("No node exist on this coordinate", null);
                
            }
            
            if (Right != null)
            {
                return new Response<T>("Found", Right);
            }
            
            return new Response<T>("No node exist on this coordinate", null);  
        }
        

        if (col > (levelSize / 2) )
        {
            if (Right != null)
            {
                return Right.Get(level - 1, levelSize - col);
            }

            return new Response<T>("No node exist on this coordinate", null);
            
        }
        else
        {
            if (Left != null)
            {
                return Left.Get(level - 1, col);
            }

            return new Response<T>("No node exist on this coordinate", null);
        }
    }

    // Checks if the value is equal to the value of the node
    // Depending on if its bigger or smaller it recursively calls the function again on either right or left
    // When it finds the value it returns a response with a message and the node holding the value
    // When it reaches a deadend or null means that the value is not in the tree and so returns a message and null
    public Response<T> Find(T value)
    {
        Console.WriteLine("Find() has been called");

        if (Value.CompareTo(value) == 0)
        {
            return new Response<T>("Found", this);
        }
        
        if (Value.CompareTo(value) > 0)
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

        return new Response<T>("Not found", null);
    }


    // Compares the value to the values of the node 
    // If the value is smaller it needs to go left and if its bigger it goes right
    // It keeps looking until it finds a null, a place to put the value. 
    // If the value already exist or it has been placed it sends a message and the node with the location
    public Response<T> Add(T value)
    {
        Console.WriteLine("Add() has been called");

        if (Value.CompareTo(value) == 0)
        {
            return new Response<T>("Value already in tree", this);
        }

        if (Value.CompareTo(value) > 0)
        {
            if (Left != null)
            {
                return Left.Add(value);
            }

            Left = new TreeNode<T>(value);
            return new Response<T>("Added", Left);
        }

        if (Right != null)
        {
            return Right.Add(value);
        }

        Right = new TreeNode<T>(value);
        return new Response<T>("Added", Right);
    }


    // Depricated?
    public Response<T> Remove(T value)
    {
        Console.WriteLine("Remove() has been called");
        if (Value.CompareTo(value) == 0)
        {
            return new Response<T>("Cant remove root node", null);
        }
        if (Value.CompareTo(value) > 0)
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

        return new Response<T>("Not found", null);
    }

    
    // Looks for the target value while storing the parent node and the direction it came from
    // When the value has been found it checks how many children this node has
    // Depending on that it calls a function that removes the node
    // Returns a message and null
    public Response<T> Remove(T value, TreeNode<T> parent, bool isLeft)
    {
        Console.WriteLine("Remove() has been called");
        if (Value.CompareTo(value) == 0)
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
        if (Value.CompareTo(value) > 0)
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

        return new Response<T>("Not found", this);
    }

    // If the node has no children it will remove the node by using the parent node reference to itself
    // Returns a message and null
    private Response<T> RemoveNoChildren(TreeNode<T> parent, bool isLeft)
    {
        if (isLeft)
        {
            parent.Left = null;
        }
        else
        {
            parent.Right = null;
        }

        return new Response<T>("Removed", parent);
    }

    // If the node has a single child it will check which direction it child goes and changes the reference in its parent node to its child node
    // Returns a message and null
    private Response<T> RemoveOneChild(TreeNode<T> parent, bool isLeft)
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

        return new Response<T>("Removed", parent);
    }

    // If the node has two children it will grab the lowest value node of its right branch to be inserted in the tree on its own place.
    // The left and right branches will be added to this new root node and the reference to this node needs to be removed from its old parent
    // Returns a message and null 
    private Response<T> RemoveTwoChildren(TreeNode<T> parent, bool isLeft)
    {
        if (Right != null && Left != null)
        {
            var newRoot = Right.Min(this)[0];
            var oldParent = Right.Min(this)[1];

            newRoot.Left = this.Left;

            if (newRoot.Value.CompareTo(this.Right.Value) != 0)
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

        return new Response<T>("Removed", null);
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
    public TreeNode<T> Min()
    {
        if (Left != null)
        {
            return Left.Min();
        }

        return this;
    }

    // It works the same as the other Min method but for one application I also need the parent node
    // Returns an array with TreeNodes
    public TreeNode<T>[] Min(TreeNode<T> parent)
    {
        if (Left != null)
        {
            return Left.Min(this);
        }

        TreeNode<T>[] package = {this, parent};
        return package;
    }

}