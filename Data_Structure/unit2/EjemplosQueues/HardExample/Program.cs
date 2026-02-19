using System;
using System.Collections.Generic;

public class TareaRed
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public int Prioridad { get; set; }
}

public class Program
{
    public static void Main()
    {
      Queue<TareaRed> colaDePaquetes = new Queue<TareaRed>();
        //FIFO - First In, First Out

        // Llegan paquetes de datos de la red
        colaDePaquetes.Enqueue(new TareaRed { Id = 101, Tipo = "Descarga" });
        colaDePaquetes.Enqueue(new TareaRed { Id = 102, Tipo = "Ping" });
        colaDePaquetes.Enqueue(new TareaRed { Id = 103, Tipo = "Subida" });

        Console.WriteLine("--- Iniciando Procesador de Red ---");

        while (colaDePaquetes.Count > 0)
        {
            TareaRed actual = colaDePaquetes.Dequeue();
            
            // Simulación de procesamiento
            Console.WriteLine($"Procesando Paquete #{actual.Id} de tipo [{actual.Tipo}]...");
            
            if (actual.Tipo == "Ping") 
                Console.WriteLine("   -> Respuesta enviada en 20ms.");
            else 
                Console.WriteLine("   -> Datos transferidos con éxito.");
        }

        Console.WriteLine("Cola vacía. Procesador en standby.");
    }
}