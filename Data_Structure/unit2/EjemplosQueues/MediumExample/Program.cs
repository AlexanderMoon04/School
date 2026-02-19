using System;
using System.Collections.Generic;

public class LogManager
{
    private Queue<string> _logs = new Queue<string>(); //the sign _ is a convention to indicate that this variable is private
    private const int MaxLogs = 5;

    public void RegistrarEvento(string evento)
    {
        if (_logs.Count == MaxLogs)
        {
            string viejo = _logs.Dequeue(); // Sacamos el más antiguo
            Console.WriteLine($"[LOG LLENO] Eliminando registro antiguo: {viejo}");
        }
        _logs.Enqueue(evento);
        Console.WriteLine($"Registrado: {evento}");
    }

    public void MostrarLogs()
    {
        Console.WriteLine("\n--- Historial Actual ---");
        foreach (var log in _logs) Console.WriteLine($"> {log}");
    }
}

public class Program
{
    public static void Main()
    {
        LogManager miApp = new LogManager();
        miApp.RegistrarEvento("Inicio de app");
        miApp.RegistrarEvento("Login usuario");
        miApp.RegistrarEvento("Carga de datos");
        miApp.RegistrarEvento("Error de red");
        miApp.RegistrarEvento("Intento 2");
        miApp.RegistrarEvento("NUEVO: Click en botón"); // Esto sacará "Inicio de app"

        miApp.MostrarLogs();
    }
}