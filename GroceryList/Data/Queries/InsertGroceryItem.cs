using Npgsql;

namespace GroceryList.Data.Queries
{
    public class InsertGroceryItem
    {
	    public InsertGroceryItem()
	    {
	    }

		//	TODO: replace connection string local variables with environment variables
	    private const string SERVER = "localhost";
	    private const string DATABASE = "GroceryListDB";
	    private const string USER = "kwik";
	    private const string PASSWORD = "pNyn8_5E";
	    private static string GetConnectionString()
	    {
		    var csBuilder = new NpgsqlConnectionStringBuilder()
		    {
			    Host = SERVER,
			    Database = DATABASE,
			    Username = USER,
			    Password = PASSWORD
		    };

		    return csBuilder.ConnectionString;
	    }

	    public void InsertGroceryItemQuery(string item, int quantity)
	    {
			// Create Database Connection
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);

			// Open Database Connection
			conn.Open();

			// Define Query
			var sql =
				"INSERT INTO GroceryItems " +
				"VALUES(:item, :quantity);";
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
		    cmd.Parameters.AddWithValue("@item", item);
		    cmd.Parameters.AddWithValue("@quantity", quantity);

			// Execute Query
		    cmd.ExecuteNonQuery();

			// Close Database Connection
			conn.Close();

	    }

    }
}

