using System;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class CreateGroceryItem
    {
	    public CreateGroceryItem()
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
//			    Host = Environment.GetEnvironmentVariable("GL_HOST"),
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
		public void CreateGroceryItemQuery(GroceryItem item)
	    {
			// Create and Open Database Connection
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

//		    if (IfExists(item.name))
//		    {
//				return true;
//		    }

			// Define Query
		    string sql =
			    "INSERT INTO GroceryItems " +
			    "VALUES (:name, :quantity);";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
		    cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
		    cmd.Parameters[0].Value = item.name.ToUpper();
		    cmd.Parameters.Add(new NpgsqlParameter("quantity", NpgsqlTypes.NpgsqlDbType.Integer));
		    cmd.Parameters[1].Value = item.quantity;

			// Execute Query
		    cmd.ExecuteNonQuery();

			// Close Database Connection
			conn.Close();
			cmd.Dispose();

//		    return false;
	    }
		 public bool CheckExistence(string name)
	    {

		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
			string sql =
				"SELECT 1 FROM GroceryItems WHERE name = :name;";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
		    cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
		    cmd.Parameters[0].Value = name.ToUpper();

			// Execute Query
//			NpgsqlDataReader dataReader = cmd.ExecuteReader();
//		    if (dataReader.Read())
			if (cmd.ExecuteScalar() != null)
		    {
			    return true;
		    }

//			dataReader.Close();
			conn.Close();
			cmd.Dispose();

			return false;
	    }

    }
}

