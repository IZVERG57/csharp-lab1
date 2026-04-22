namespace TreeRecursion;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Tree Recursion Demo (pre-order) ===");

        TreeNode root = BuildTree();

        Console.WriteLine("Tree values:");
        root.PrintPreOrder();
    }

    private static TreeNode BuildTree()
    {
        TreeNode root = new("Root");

        TreeNode a = new("A");
        TreeNode b = new("B (leaf)");
        TreeNode c = new("C");

        TreeNode a1 = new("A1 (leaf)");
        TreeNode a2 = new("A2");
        TreeNode a21 = new("A2.1 (leaf)");

        TreeNode c1 = new("C1");
        TreeNode c11 = new("C1.1");
        TreeNode c111 = new("C1.1.1 (leaf)");

        a2.AddChild(a21);
        a.AddChild(a1).AddChild(a2);

        c11.AddChild(c111);
        c1.AddChild(c11);
        c.AddChild(c1);

        root.AddChild(a).AddChild(b).AddChild(c);

        return root;
    }
}
