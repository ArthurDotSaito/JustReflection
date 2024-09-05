namespace JustReflection;

public class ExampleClass
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public void Print()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
    }
    
    [MethodRunFor(RunCount = 1)]
    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }

    [MethodRunFor(RunCount = 3)]
    public void TestExampleClass()
    {
        Console.WriteLine("Hello from ExampleClass!");
    }
}