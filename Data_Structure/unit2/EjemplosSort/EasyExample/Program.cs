using System;

public class Program
{
    public static void Main()
    {
        int[] edades = { 25, 18, 42, 12, 30 };

        // Burbuja: El más grande "flota" hacia el final
        // i controla cuántas "pasadas" hacemos. 
        // Con cada pasada, el número más grande queda al final.
        for (int i = 0; i < edades.Length - 1; i++)
        {
            // j recorre el array comparando parejas.
            // Restamos 'i' porque los últimos 'i' elementos ya están ordenados.
            for (int j = 0; j < edades.Length - i - 1; j++)
            {
                // Si el de la izquierda es mayor que el de la derecha...
                if (edades[j] > edades[j + 1])
                {
                    // SWAP: Usamos 'aux' como una caja temporal para no perder el valor.
                    int aux = edades[j];     // Guardo el valor A
                    edades[j] = edades[j + 1]; // Pongo B en el lugar de A
                    edades[j + 1] = aux;      // Pongo A en el lugar de B
                }
            }
        }
        Console.WriteLine("Edades ordenadas: " + string.Join(", ", edades));
    }
}