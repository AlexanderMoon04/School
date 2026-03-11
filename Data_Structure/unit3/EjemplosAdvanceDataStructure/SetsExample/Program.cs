using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedDataStructuresSets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SETS DEMONSTRATION ---\n");

            // 3.1 DEFINITION: Creation and Uniqueness
            Console.WriteLine("1. Definition (Uniqueness):");
            HashSet<string> colors = new HashSet<string>();
            colors.Add("Red");
            colors.Add("Blue");
            colors.Add("Red"); // This will not be added

            Console.WriteLine($"Unique Colors: {string.Join(", ", colors)}");
            Console.WriteLine($"Count: {colors.Count} (It is 2, not 3)\n");

            // 3.2 COMPONENTS: Practical Function (Fast Search)
            Console.WriteLine("2. Components (Fast Search):");
            string search = "Blue";
            if (colors.Contains(search))
            {
                Console.WriteLine($"The color '{search}' exists in the set.");
            }
            else
            {
                Console.WriteLine($"The color '{search}' does not exist.");
            }

            // 3.3 OPERATIONS: Union, Intersection, Difference, Symmetric Difference
            Console.WriteLine("\n3. Set Operations:");
            HashSet<int> numbersA = new HashSet<int> { 1, 2, 3, 4 };
            HashSet<int> numbersB = new HashSet<int> { 3, 4, 5, 6 };

            // Intersection
            var common = numbersA.Intersect(numbersB);
            Console.WriteLine($"Common (Intersection): {string.Join(", ", common)}");

            // Difference (Only in A)
            var onlyA = numbersA.Except(numbersB);
            Console.WriteLine($"Only in A (Difference): {string.Join(", ", onlyA)}");

            // Union
            var all = numbersA.Union(numbersB);
            Console.WriteLine($"All (Union): {string.Join(", ", all)}");

            // Symmetric Difference
            var symmetricDiff = numbersA.Except(numbersB).Union(numbersB.Except(numbersA));
            Console.WriteLine($"Symmetric Difference: {string.Join(", ", symmetricDiff)}"); // Output: 1, 2, 4, 5

            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }
}