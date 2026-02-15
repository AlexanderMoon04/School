using System;
using System.Collections.Generic;

public class Program
{
   public static void Main()
   {
      LinkedList<string> tareas = new LinkedList<string>();
      tareas.AddLast("tarea 1: revisar correo");
      tareas.AddLast("tarea 3: Almorzar");

      //1. buscar un nodo especifico
      LinkedListNode<string> nodoReferencia = tareas.Find("tarea 1: revisar correo");
      if (nodoReferencia != null)
      {
         //2. insertamos justo despues de ese nodo (sin mover indices como en list<T>)
         tareas.AddAfter(nodoReferencia, "tarea 2: llamar al cliente (urgente)");
      }
      //3. eleminar el ultimo elemento de forma eficiente
      tareas.RemoveLast();

      Console.WriteLine("lista de tareas actualizada: ");
      var nodoIterador = tareas.First;
      while (nodoIterador != null)
      {
         Console.WriteLine($"[ ] {nodoIterador.Value}");
         nodoIterador = nodoIterador.Next;//recorrido manual por nodos
      }


   }
}