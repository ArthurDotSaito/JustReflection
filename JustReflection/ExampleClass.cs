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
}