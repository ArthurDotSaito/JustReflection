namespace JustReflection;

public class ExampleClass
{
    public string Name { get; set; }
    public string Description { get; set; }

    [MethodRunFor(RunCount = 5)]
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
}