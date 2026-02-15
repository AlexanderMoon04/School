using System;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        LinkedList<string> historial = new LinkedList<string>();
        //añadir al incio y al final
        historial.AddLast("google.com");
        historial.AddLast("github.com");
        historial.AddFirst("openai.com"); //se vuelve la nueva "portada

        Console.WriteLine("historial de navegacion:");
        foreach(var sitio in historial)
        {
            Console.WriteLine($"->{sitio}");
        }
        historial.AddFirst("youtube.com");
        LinkedListNode<string> nodoGithub =historial.Find("github.com"); //aqui se busca el nodo en el cual este github 
        if(nodoGithub != null)
        {
            historial.AddAfter(nodoGithub, "facebook.com"); //y aqui usas la variable donde se guardo github y se pone un nuevo elemento despues en la lista
        }
        
        
        Console.WriteLine("Nuevo historial de navegacion:");
        foreach(var sitio in historial)
        {
            Console.WriteLine($"->{sitio}");
        }

    }
}