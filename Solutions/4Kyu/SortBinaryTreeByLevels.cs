//https://www.codewars.com/kata/52bef5e3588c56132c0003bc

using System.Collections.Generic;

public class Node
{
    public Node Left;
    public Node Right;
    public int Value;

    public Node(Node l, Node r, int v)
    {
        Left = l;
        Right = r;
        Value = v;
    }
}

class Kata
{
    public static List<int> TreeByLevels(Node node)
    {
        if (node == null) return new List<int>();
        Queue<Node> CheckNode = new Queue<Node>();
        List<int> Result = new List<int>();
        CheckNode.Enqueue(node);

        while (CheckNode.Count > 0)
        {
            Node n = CheckNode.Dequeue();
            Result.Add(n.Value);
            if (n.Left != null) CheckNode.Enqueue(n.Left);
            if (n.Right != null) CheckNode.Enqueue(n.Right);
        }
        return Result;
    }
}