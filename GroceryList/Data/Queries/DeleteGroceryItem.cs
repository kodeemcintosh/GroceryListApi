using System;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class DeleteGroceryItem
    {
	    public DeleteGroceryItem()
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
		public void DeleteGroceryItemQuery(string name)
	    {
			// Create and Open Database connection
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			string sql =
				"DELETE FROM GroceryItems " +
				"WHERE (name = :name);";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
			cmd.Parameters[0].Value = name.ToUpper();

			// Run the query
			cmd.ExecuteNonQuery();

			// Close Database Connection
			conn.Close();
	    }

		internal void RemoveGroceryItemQuery(GroceryItem dataRequest)
		{
			throw new NotImplementedException();
		}
	}
}
