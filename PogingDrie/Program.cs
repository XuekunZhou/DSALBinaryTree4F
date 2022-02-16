public class Program
{
    public static void Main(string[] args)
    {
        var tree = new Tree<string>("Hello");
        tree.Add("World!");
        tree.Add("I have no idea");
        tree.Add("Comon!");

        Console.WriteLine(tree.Find("").Message);
        Console.WriteLine(tree.Find("World!").Message);
    }

    
}
