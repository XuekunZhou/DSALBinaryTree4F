public class Program
{
    public static void Main(string[] args)
    {
        var tree = GenerateTree();

        tree.Add(47);
        tree.Add(14);

        tree.Remove(17);

        Console.WriteLine(tree.Find(30).Result.Left.Value);

        for (int i = 1; i < 60; i++)
        {
            Console.WriteLine(i + ": " + tree.Find(i).Message);
        }
    }

    public static Tree GenerateTree()
    {
        TreeNode leaf1 = new TreeNode(1);
        TreeNode leaf5 = new TreeNode(5);
        TreeNode leaf11 = new TreeNode(11);
        TreeNode leaf13 = new TreeNode(13);
        TreeNode leaf21 = new TreeNode(21);
        TreeNode leaf35 = new TreeNode(35);
        TreeNode leaf50 = new TreeNode(50);


        TreeNode branch4 = new TreeNode(4);
        branch4.Left = leaf1;
        branch4.Right = leaf5;

        TreeNode branch12 = new TreeNode(12);
        branch12.Left = leaf11;
        branch12.Right = leaf13;

        TreeNode branch27 = new TreeNode(27);
        branch27.Left = leaf21;

        TreeNode branch42 = new TreeNode(42);
        branch42.Left = leaf35;
        branch42.Right = leaf50;


        TreeNode branch9 = new TreeNode(9);
        branch9.Left = branch4;
        branch9.Right = branch12;

        TreeNode branch30 = new TreeNode(30);
        branch30.Left = branch27;
        branch30.Right = branch42;


        TreeNode root17 = new TreeNode(17);
        root17.Left = branch9;
        root17.Right = branch30;

        Tree tree = new Tree(17);
        tree.Root = root17;

        return tree;
    }

    public static Tree GenerateTree2()
    {
        var tree = new Tree(17);
        tree.Add(1);
        tree.Add(4);
        tree.Add(5);
        tree.Add(9);
        tree.Add(12);
        tree.Add(11);
        tree.Add(13);
        tree.Add(35);
        tree.Add(27);
        tree.Add(21);
        tree.Add(42);
        tree.Add(35);
        tree.Add(50);
        tree.Add(30);

        return tree;
    }
}
