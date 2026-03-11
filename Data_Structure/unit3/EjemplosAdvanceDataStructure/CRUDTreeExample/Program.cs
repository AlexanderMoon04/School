using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value) => Value = value;
}

public class BinarySearchTree
{
    public TreeNode? Root;

    // --- OPERACIONES CRUD ---

    public void Insert(int value) => Root = InsertRecursive(Root, value);

    private TreeNode InsertRecursive(TreeNode? root, int value)
    {
        if (root == null) return new TreeNode(value);
        if (value < root.Value) root.Left = InsertRecursive(root.Left, value);
        else if (value > root.Value) root.Right = InsertRecursive(root.Right, value);
        return root;
    }

    public bool Search(int value) => SearchRecursive(Root, value);

    private bool SearchRecursive(TreeNode? root, int value)
    {
        if (root == null) return false;
        if (root.Value == value) return true;
        return value < root.Value ? SearchRecursive(root.Left, value) : SearchRecursive(root.Right, value);
    }

    public void Delete(int value) => Root = DeleteRecursive(Root, value);

    private TreeNode? DeleteRecursive(TreeNode? root, int value)
    {
        if (root == null) return null;

        if (value < root.Value) root.Left = DeleteRecursive(root.Left, value);
        else if (value > root.Value) root.Right = DeleteRecursive(root.Right, value);
        else {
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;
            root.Value = MinValue(root.Right);
            root.Right = DeleteRecursive(root.Right, root.Value);
        }
        return root;
    }

    private int MinValue(TreeNode node)
    {
        int min = node.Value;
        while (node.Left != null) { min = node.Left.Value; node = node.Left; }
        return min;
    }

    // --- MÉTODO DE VISUALIZACIÓN ---

    public void PrintVisual(TreeNode? node, string indent = "", bool last = true)
    {
        if (node == null) return;

        Console.Write(indent);
        if (last) {
            Console.Write("└─");
            indent += "  ";
        } else {
            Console.Write("├─");
            indent += "│ ";
        }
        Console.WriteLine(node.Value);

        var children = new List<TreeNode>();
        if (node.Left != null) children.Add(node.Left);
        if (node.Right != null) children.Add(node.Right);

        for (int i = 0; i < children.Count; i++)
        {
            PrintVisual(children[i], indent, i == children.Count - 1);
        }
    }
}

public class Program
{
    public static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        // 1. Insertar datos (Ejemplo: años de modelos o códigos de parte)
        int[] datos = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (var d in datos) bst.Insert(d);

        Console.WriteLine("=== Estructura Inicial del Árbol ===");
        bst.PrintVisual(bst.Root);

        // 2. Buscar
        Console.WriteLine($"\n¿Buscando el 40?: {(bst.Search(40) ? "Encontrado" : "No existe")}");

        // 3. Eliminar y ver cambio
        Console.WriteLine("\n=== Eliminando el 70 (Nodo con dos hijos) ===");
        bst.Delete(70);
        bst.PrintVisual(bst.Root);
        
        Console.WriteLine("\n=== Eliminando el 30 ===");
        bst.Delete(30);
        bst.PrintVisual(bst.Root);
    }
}