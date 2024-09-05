using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace JustReflection.EF;

public class CreateTable
{
    public static void CreateSQLTable(Type type, string tableName = null)
    {
        var connectionString = "server=localhost;port=3307;database=reflection;user=root;password=root";
        try
        {
            using (var dbConnection = new MySqlConnection(connectionString))
            {
                var properties = type.GetProperties();
                var queryBuilder = new StringBuilder();
                queryBuilder.Append($"CREATE TABLE `{tableName}` (");
                var columns = new List<string>();

                foreach (var prop in properties)
                {
                    if (prop.Name.ToLower() == "id" && prop.PropertyType.Name == "Int32")
                        columns.Add("Id INT PRIMARY KEY AUTO_INCREMENT");
            
                    if(prop.PropertyType.Name == "String")
                        columns.Add($"{prop.Name} VARCHAR(255)");
                }
        
                string columnsString = string.Join(", ", columns);

                queryBuilder.Append(columnsString);
                queryBuilder.Append(")");
        
                var command = new MySqlCommand(queryBuilder.ToString(), dbConnection);
                dbConnection.Open();
                command.ExecuteNonQuery();
        
                dbConnection.Close();
                Console.WriteLine($"{tableName} table created successfully!");
            }
        }catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}