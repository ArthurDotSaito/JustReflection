using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace JustReflection.EF;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
    }

    static void CreateSQLTable(Type type, string tableName = null)
    {
        var dbConnection = new SqlConnection("server=localhost;database=reflection;integrated security=true;");

        var properties = type.GetProperties();
        var queryBuilder = new StringBuilder();
        queryBuilder.Append($"CREATE TABLE {tableName}");
        var columns = new List<string>();

        foreach (var prop in properties)
        {
            if (prop.Name.ToLower() == "id" && prop.PropertyType.Name == "Int32")
                columns.Add("Id INT PRIMARY KEY IDENTITY(1,1)");
            
            if(prop.PropertyType.Name == "String")
                columns.Add($"{prop.Name} nvarchar(max)");
        }
        
        string columnsString = string.Join(", ", columns);

        queryBuilder.Append(columnsString);
        queryBuilder.Append(")");
        
        var command = new SqlCommand(queryBuilder.ToString(), dbConnection);
        dbConnection.Open();
        command.ExecuteNonQuery();
        
        dbConnection.Close();
        Console.WriteLine($"{tableName} table created successfully!");
    }
    
}