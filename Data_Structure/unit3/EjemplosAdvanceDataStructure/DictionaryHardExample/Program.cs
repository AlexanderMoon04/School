using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // El Valor ahora es del tipo 'InfoContacto'
        var agenda = new Dictionary<string, InfoContacto>();

        // --- CREATE ---
        agenda.Add("Ana", new InfoContacto { 
            Telefono = "555-1234", 
            Correo = "ana@email.com", 
            Vehiculo = "Nissan Tsuru 1998" 
        });

        agenda.Add("Carlos", new InfoContacto { 
            Telefono = "555-6789", 
            Correo = "carlos@email.com", 
            Vehiculo = "Volkswagen Pointer 2007" 
        });

        // --- READ (Acceso a datos específicos) ---
        if (agenda.ContainsKey("Ana"))
        {
            // Primero obtenemos el objeto completo asociado a "Ana"
            InfoContacto datosAna = agenda["Ana"];
            
            Console.WriteLine($"--- Ficha de Ana ---");
            Console.WriteLine($"Teléfono: {datosAna.Telefono}");
            Console.WriteLine($"Correo: {datosAna.Correo}");
            Console.WriteLine($"Vehículo: {datosAna.Vehiculo}");
        }

        // --- UPDATE ---
        // Si Ana cambia de correo, solo modificamos esa propiedad del objeto
        if (agenda.ContainsKey("Ana"))
        {
            agenda["Ana"].Correo = "ana_nuevo@email.com";
            Console.WriteLine("\n[Update] Correo de Ana actualizado.");
        }

        // --- LISTAR TODO ---
        Console.WriteLine("\n--- Agenda Completa ---");
        foreach (var entrada in agenda)
        {
            // entrada.Key es el nombre
            // entrada.Value es el objeto InfoContacto
            Console.WriteLine($"{entrada.Key.ToUpper()}: {entrada.Value.Telefono} | {entrada.Value.Correo} | {entrada.Value.Vehiculo}");
        }
    }
}