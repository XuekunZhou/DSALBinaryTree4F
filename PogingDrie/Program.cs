public class Program
{
    public static void Main(string[] args)
    {
        var tree = GenerateTree();

        for (int i = 1; i < 60; i++)
        {
            Console.WriteLine(i + ": " + tree.Find(i).Message);
        }
    }

    public static Tree<int> GenerateTree()
    {
        TreeNode<int> leaf1 = new TreeNode<int>(1);
        TreeNode<int> leaf5 = new TreeNode<int>(5);
        TreeNode<int> leaf11 = new TreeNode<int>(11);
        TreeNode<int> leaf13 = new TreeNode<int>(13);
        TreeNode<int> leaf21 = new TreeNode<int>(21);
        TreeNode<int> leaf35 = new TreeNode<int>(35);
        TreeNode<int> leaf50 = new TreeNode<int>(50);


        TreeNode<int> branch4 = new TreeNode<int>(4);
        branch4.Left = leaf1;
        branch4.Right = leaf5;

        TreeNode<int> branch12 = new TreeNode<int>(12);
        branch12.Left = leaf11;
        branch12.Right = leaf13;

        TreeNode<int> branch27 = new TreeNode<int>(27);
        branch27.Left = leaf21;

        TreeNode<int> branch42 = new TreeNode<int>(42);
        branch42.Left = leaf35;
        branch42.Right = leaf50;


        TreeNode<int> branch9 = new TreeNode<int>(9);
        branch9.Left = branch4;
        branch9.Right = branch12;

        TreeNode<int> branch30 = new TreeNode<int>(30);
        branch30.Left = branch27;
        branch30.Right = branch42;


        TreeNode<int> root17 = new TreeNode<int>(17);
        root17.Left = branch9;
        root17.Right = branch30;

        Tree<int> tree = new Tree<int>();
        tree.Root = root17;

        return tree;
    }
}
