using System;
using System.Collections.Generic; // Necesario para Queue (BFS)

public class TreeNode
{
    public int Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value)
    {
        Value = value;
    }
}

public class Program
{
    public static void Main()
    {
        // Estructura del árbol:
        //                      1 (root/Parent)
        //                     / \
        // (Child/Parent)     2   3     (Child/Leaf)
        //                   / \
        // (Child/Leaf)     4   5     (Child/Leaf)
        var root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);

        Console.WriteLine("1. Preorden (R-I-D):");
        TraversePreOrder(root);
        Console.WriteLine("\n\n2. Inorden (I-R-D):");
        TraverseInOrder(root);
        Console.WriteLine("\n\n3. Postorden (I-D-R):");
        TraversePostOrder(root);
        Console.WriteLine("\n\n4. Por Niveles (BFS):");
        TraverseLevelOrder(root);
    }

    // --- RECORRIDOS Depth-First Search  (DFS) ---

    public static void TraversePreOrder(TreeNode? node)
    {
        if (node == null) return;
        Console.Write(node.Value + " "); // Raíz
        TraversePreOrder(node.Left);     // Izquierda
        TraversePreOrder(node.Right);    // Derecha
    }

    public static void TraverseInOrder(TreeNode? node)
    {
        if (node == null) return;
        TraverseInOrder(node.Left);      // Izquierda
        Console.Write(node.Value + " "); // Raíz
        TraverseInOrder(node.Right);     // Derecha
    }

    public static void TraversePostOrder(TreeNode? node)
    {
        if (node == null) return;
        TraversePostOrder(node.Left);    // Izquierda
        TraversePostOrder(node.Right);   // Derecha
        Console.Write(node.Value + " "); // Raíz
    }

    // --- RECORRIDO Breadth-First Search (BFS) ---

    public static void TraverseLevelOrder(TreeNode? root)
    {
        if (root == null) return;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root); // Empezamos por la raíz

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue(); // Sacamos el primero en la fila
            Console.Write(node.Value + " ");

            // Agregamos los hijos a la fila para ser visitados después
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
        }
    }
}