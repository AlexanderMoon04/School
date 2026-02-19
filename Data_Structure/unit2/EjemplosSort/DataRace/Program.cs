using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // 1. Generar datos aleatorios
        int tamano = 10000; 
        int[] datosOriginales = Enumerable.Range(1, tamano).OrderBy(x => Guid.NewGuid()).ToArray();
        int objetivo = datosOriginales[tamano / 2]; // Buscaremos un número que exista

        Console.WriteLine($"--- Iniciando Carrera con {tamano} elementos ---");

        // --- SECCIÓN DE ORDENAMIENTO ---
        
        // BUBBLE SORT
        int[] arrBubble = (int[])datosOriginales.Clone();
        Stopwatch sw = Stopwatch.StartNew();
        BubbleSort(arrBubble);
        sw.Stop();
        Console.WriteLine($"1. Bubble Sort: {sw.ElapsedMilliseconds} ms (O(n²))");

        // INSERTION SORT
        int[] arrInsertion = (int[])datosOriginales.Clone();
        sw.Restart();
        InsertionSort(arrInsertion);
        sw.Stop();
        Console.WriteLine($"2. Insertion Sort: {sw.ElapsedMilliseconds} ms (O(n²))");

        // C# NATIVE SORT (QuickSort/IntroSort)
        int[] arrNative = (int[])datosOriginales.Clone();
        sw.Restart();
        Array.Sort(arrNative);
        sw.Stop();
        Console.WriteLine($"3. C# Array.Sort: {sw.ElapsedMilliseconds} ms (O(n log n)) - EL GANADOR");

        Console.WriteLine("\n--- Sección de Búsqueda ---");

        // LINEAR SEARCH
        sw.Restart();
        LinearSearch(datosOriginales, objetivo);
        sw.Stop();
        Console.WriteLine($"1. Linear Search: {sw.Elapsed.TotalMilliseconds} ms (O(n))");

        // BINARY SEARCH (Usando el array ya ordenado)
        sw.Restart();
        BinarySearch(arrNative, objetivo);
        sw.Stop();
        Console.WriteLine($"2. Binary Search: {sw.Elapsed.TotalMilliseconds} ms (O(log n)) - INSTANTÁNEO");
    }

    // --- ALGORITMOS ---

    static void BubbleSort(int[] arr) {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j + 1]) {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }

    static void InsertionSort(int[] arr) {
        for (int i = 1; i < arr.Length; i++) {
            int clave = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > clave) {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = clave;
        }
    }

    static int LinearSearch(int[] arr, int t) {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == t) return i;
        return -1;
    }

    static int BinarySearch(int[] arr, int t) {
        int izq = 0, der = arr.Length - 1;
        while (izq <= der) {
            int m = izq + (der - izq) / 2;
            if (arr[m] == t) return m;
            if (arr[m] < t) izq = m + 1;
            else der = m - 1;
        }
        return -1;
    }
}