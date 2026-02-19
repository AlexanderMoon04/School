using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Queue<string> filaImpresion = new Queue<string>();

        // Enqueue: Agrega al final de la cola
        filaImpresion.Enqueue("Reporte_Mensual.pdf");
        filaImpresion.Enqueue("Foto_Vacaciones.jpg");
        filaImpresion.Enqueue("Ticket_Venta.txt");

        Console.WriteLine($"Siguiente documento en espera: {filaImpresion.Peek()}");

        // Dequeue: Remueve el primero que llegó
        while (filaImpresion.Count > 0)
        {
            string documento = filaImpresion.Dequeue();
            Console.WriteLine($"Imprimiendo: {documento}... ¡Listo!");
        }
    }
}