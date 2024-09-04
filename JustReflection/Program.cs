using System;
using System.Reflection;

namespace JustReflection;
class Program
{
    static void Main()
    {
        Type exampleClassType = typeof(ExampleClass);

        var properties = exampleClassType.GetProperties();
        foreach (var prop in properties)
        {
            Console.WriteLine($"Property Type: {prop.PropertyType.Name} | Property Name: {prop.Name}");
        }

        Console.ReadKey();
    }
}