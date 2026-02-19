using System;

public class Program
{
    public static void Main()
    {
        string[] nombres = { "Zulema", "Bernardo", "Carlos", "Alberto", "Diana" };

        // Insertion Sort: Como ordenar cartas en la mano
        for (int i = 1; i < nombres.Length; i++)
        {
            string clave = nombres[i]; // El elemento que vamos a "insertar".
            int j = i - 1; // Empezamos a comparar con el que está a su izquierda.

            // Mientras no lleguemos al inicio (j >= 0) 
            // Y el elemento de la izquierda sea "mayor" alfabéticamente que nuestra clave...
            while (j >= 0 && nombres[j].CompareTo(clave) > 0)
            {
                nombres[j + 1] = nombres[j]; // DESPLAZAMIENTO: Movemos el mayor a la derecha.
                j--; // Seguimos retrocediendo hacia la izquierda.
            }

            // Ponemos la clave en el hueco que quedó libre.
            nombres[j + 1] = clave;
        }

        Console.WriteLine("Nombres alfabéticos: " + string.Join(", ", nombres));
    }
}