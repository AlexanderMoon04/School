using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Inicialización del Diccionario
        Dictionary<string, string> contactos = new Dictionary<string, string>();

        // 1. CREATE (Crear)
        // Podemos usar .Add() o el indexador []
        contactos.Add("Ana", "555-1234");
        contactos.Add("Carlos", "555-5678");
        contactos["Sofia"] = "555-0000"; // También crea si la llave no existe
        Console.WriteLine("|-- Elementos Creados --|");
        Console.WriteLine("|-----------------------|");

        // 2. READ (Leer)
        // Leer un valor específico
        if (contactos.ContainsKey("Ana")) 
        {
            Console.WriteLine($"El teléfono de Ana es: {contactos["Ana"]}");
        }

        // Leer/Listar todos (Iteración)
        Console.WriteLine("\nLista completa de contactos:");
        foreach (KeyValuePair<string, string> contacto in contactos)
        {
            Console.WriteLine($"Nombre: {contacto.Key}, Teléfono: {contacto.Value}");
        }

        // 3. UPDATE (Actualizar)
        // Simplemente asignamos un nuevo valor a una llave existente
        if (contactos.ContainsKey("Carlos"))
        {
            contactos["Carlos"] = "555-8888"; 
            Console.WriteLine("\n[Update] El teléfono de Carlos ha sido actualizado.");
        }

        // 4. DELETE (Borrar)
        // Eliminamos por llave
        bool eliminado = contactos.Remove("Sofia");
        if (eliminado)
        {
            Console.WriteLine("[Delete] Sofia ha sido eliminada de la lista.");
        }

        bool eliminado2 = contactos.Remove("Sofia");
        if (eliminado2)
        {
            Console.WriteLine("[Delete] Sofia ha sido eliminada de la lista.");
        }
        else
        {
            Console.WriteLine("[Testing] No existe el contacto Sofia.");
        }

        // Verificación final (Read después de cambios)
        Console.WriteLine("\n--- Estado final del Diccionario ---");
        foreach (var item in contactos)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}