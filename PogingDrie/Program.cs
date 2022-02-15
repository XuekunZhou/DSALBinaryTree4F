public class Program
{
    public static void Main(string[] args)
    {
        var root = GenerateTree();

        root.Add(47);
        root.Add(14);

        if (root.Find(27).Result.Left == null)
        {
            Console.WriteLine("You ffed");
        }

        root.Remove(17);

        Console.WriteLine(root.Find(30).Result.Left.Value);

        for (int i = 1; i < 60; i++)
        {
            Console.WriteLine(i + ": " + root.Find(i).Message);
        }

        // Console.WriteLine("42: " + root.Find(42).Message);
    }

    public static Tree GenerateTree()
    {
        Tree leaf1 = new Tree(1);
        Tree leaf5 = new Tree(5);
        Tree leaf11 = new Tree(11);
        Tree leaf13 = new Tree(13);
        Tree leaf21 = new Tree(21);
        Tree leaf35 = new Tree(35);
        Tree leaf50 = new Tree(50);


        Tree branch4 = new Tree(4);
        branch4.Left = leaf1;
        branch4.Right = leaf5;

        Tree branch12 = new Tree(12);
        branch12.Left = leaf11;
        branch12.Right = leaf13;

        Tree branch27 = new Tree(27);
        branch27.Left = leaf21;

        Tree branch42 = new Tree(42);
        branch42.Left = leaf35;
        branch42.Right = leaf50;


        Tree branch9 = new Tree(9);
        branch9.Left = branch4;
        branch9.Right = branch12;

        Tree branch30 = new Tree(30);
        branch30.Left = branch27;
        branch30.Right = branch42;


        Tree root17 = new Tree(17);
        root17.Left = branch9;
        root17.Right = branch30;

        return root17;
    }
}
