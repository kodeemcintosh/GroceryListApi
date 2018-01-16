using System;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class UpdateGroceryList
    {
	    public UpdateGroceryList()
	    {
	    }

		//	TODO: replace connection string local variables with environment variables
	    private const string SERVER = "localhost";
	    private const string DATABASE = "gl_db";
	    private const string USER = "gl_user";
	    private const string PASSWORD = "cbf5fbb4-636b-4ce7-81d5-3dda794abd31";
	    private static string GetConnectionString()
	    {
		    var csBuilder = new NpgsqlConnectionStringBuilder()
		    {
//				Host = Environment.GetEnvironmentVariable("GL_HOST"),
//			    Database = Environment.GetEnvironmentVariable("GL_DATABASE"),
//			    Username = Environment.GetEnvironmentVariable("GL_USER"),
//			    Password = Environment.GetEnvironmentVariable("GL_PASSWORD")
				Host = SERVER,
			    Database = DATABASE,
			    Username = USER,
			    Password = PASSWORD
		    };

		    return csBuilder.ConnectionString;
	    }

	    public void UpdateGroceryListQuery(GroceryItem Request)
	    {
			// Create and Open Database Connection
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
		    string sql =
			    "UPDATE " +
					"GroceryItems SET quantity = ((select quantity FROM GroceryItems WHERE name = :name) + :quantity) " +
			    "WHERE name = :name;";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
		    cmd.Parameters[0].Value = Request.name.ToUpper();
		    cmd.Parameters.Add(new NpgsqlParameter("quantity", NpgsqlTypes.NpgsqlDbType.Integer));
		    cmd.Parameters[1].Value = Request.quantity;
			cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
		    cmd.Parameters[2].Value = Request.name.ToUpper();

			// Execute Query
		    cmd.ExecuteNonQuery();

			// Close Database Connection
			conn.Close();
			cmd.Dispose();
	    }
    }
}

