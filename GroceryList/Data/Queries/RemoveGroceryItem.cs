using System;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class RemoveGroceryItem
    {
	    public RemoveGroceryItem()
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

		public void RemoveGroceryItemQuery(GroceryItem Item)
	    {
		    // Create and Open Database connection
		    var connectionString = GetConnectionString();
		    NpgsqlConnection conn = new NpgsqlConnection(connectionString);
		    conn.Open();

		    if (Item.quantity == 0)
		    {
			    Console.WriteLine("This item is not on the Grocery List");
		    }
		    else
		    {

			    string sql =
					"UPDATE " +
						"GroceryItems SET quantity = quantity - :quantity " +
					"WHERE name = :name AND quantity >= :quantity;";

			    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			    cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
			    cmd.Parameters[0].Value = Item.name.ToUpper();
			    cmd.Parameters.Add(new NpgsqlParameter("quantity", NpgsqlTypes.NpgsqlDbType.Integer));
			    cmd.Parameters[1].Value = Item.quantity;

			    // Run query
			    cmd.ExecuteNonQuery();

			    // Close Database Connection
			    conn.Close();
		    }
	    }
    }
}

