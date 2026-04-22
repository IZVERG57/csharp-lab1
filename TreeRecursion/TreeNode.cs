using System.Collections.Generic;

namespace TreeRecursion;

public sealed class TreeNode
{
    public string Value { get; }
    public List<TreeNode> Children { get; } = new();

    public TreeNode(string value)
    {
        Value = value;
    }

    public TreeNode AddChild(TreeNode child)
    {
        Children.Add(child);
        return this;
    }

    public void PrintPreOrder(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}- {Value}");

        foreach (TreeNode child in Children)
        {
            child.PrintPreOrder(depth + 1);
        }
    }
}
