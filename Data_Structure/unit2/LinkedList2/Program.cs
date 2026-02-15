using System;
using System.Collections.Generic;

public class Program
{
   public static void Main()
   {
      LinkedList<string> playlist = new LinkedList<string>();
      playlist.AddLast("Song A");
      playlist.AddLast("Song B");
      playlist.AddLast("Song C");

      //obtenemos el nodo actuall (el puntero)
      LinkedListNode<string> cancionActual = playlist.First;
      Console.WriteLine($"reproduciendo: {cancionActual.Value}");

      //moverse al siguiente
      cancionActual = cancionActual.Next;
      Console.WriteLine($"siguiente: {cancionActual.Value}");

      //moverse al anterior
      cancionActual = cancionActual.Previous;
      Console.WriteLine($"volviendo a: {cancionActual.Value}");

   }
}