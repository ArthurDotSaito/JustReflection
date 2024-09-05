
namespace JustReflection.EF;
class Program
{
    static void Main()
    {
        CreateTable.CreateSQLTable(typeof(Person), "People");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public class Person()
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
    }
    
    
}