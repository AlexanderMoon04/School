using System;
using System.Collections.Generic;

public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Producto> carrito = new List<Producto>
        {
            new Producto { Nombre = "Teclado", Precio = 50.0 },
            new Producto { Nombre = "Mouse", Precio = 20.5 },
            new Producto { Nombre = "Monitor", Precio = 150.0 }
        };

        // Selection Sort: Busca el mínimo y lo posiciona
        for (int i = 0; i < carrito.Count - 1; i++)
        {
            // Asumimos que el primer elemento de la parte no ordenada es el mínimo.
            int minIndex = i;

            // Buscamos en el RESTO del array si hay alguien más pequeño.
            for (int j = i + 1; j < carrito.Count; j++)
            {
                if (carrito[j].Precio < carrito[minIndex].Precio)
                {
                    minIndex = j; // Actualizamos el índice, NO el valor aún.
                }
            }

            // INTERCAMBIO ÚNICO: Solo al final de la búsqueda movemos los objetos.
            var temp = carrito[minIndex];
            carrito[minIndex] = carrito[i];
            carrito[i] = temp;
        }

        foreach (var p in carrito)
            Console.WriteLine($"{p.Nombre}: ${p.Precio}");
    }
}