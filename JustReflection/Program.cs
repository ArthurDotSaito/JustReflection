using System;
using System.Reflection;

namespace JustReflection;
class Program
{
    static void Main()
    {
        Type exampleClassType = typeof(ExampleClass);

        var properties = exampleClassType.GetProperties();
        var methods = exampleClassType.GetMethods();
        foreach (var prop in properties)
            Console.WriteLine($"Property Type: {prop.PropertyType.Name} | Property Name: {prop.Name}");

        var exampleClass = new ExampleClass();
        exampleClass.Print();
        foreach (var method in methods)
        {
            Console.WriteLine($"Method Name: {method.Name}");
            if(method.Name == "Print") method.Invoke(exampleClass, null);
        }
        Console.WriteLine("-------------------------------------------------------");
        AttributeTest(typeof(ExampleClass));
        
        Console.ReadKey();
    }

    static void AttributeTest(Type type)
    {
        var allMethods = type.GetMethods();
        var methodsWithAttributes = allMethods
            .Where(m => m.GetCustomAttributes<MethodRunForAttribute>().Any());

        var obj = Activator.CreateInstance(type);
        
        foreach (var method in methodsWithAttributes)
        {
            var attribute = method.GetCustomAttribute<MethodRunForAttribute>();
            Console.WriteLine($"{method.Name} will run {attribute.RunCount} times");
            method.Invoke(obj, null);
        }
    }
}