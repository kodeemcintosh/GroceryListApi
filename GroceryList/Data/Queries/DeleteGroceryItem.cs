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
	    public void DeleteGroceryItemQuery(string item, int quantity)
	    {
		    var connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);

			conn.Open();

		    if (quantity == 0)
		    {
			    Console.WriteLine("This item is not on the Grocery List");
		    }
		    else
		    {
			    string sql =
				    "CASE " +
						"(WHEN ((SELECT quantity FROM GroceryItems WHERE item = :item) <= :quantity) " +
						"THEN (DELETE FROM GroceryItems WHERE item = :item, quantity) FROM GroceryItems WHERE item = :item)) " +

						"(WHEN ((SELECT quantity FROM GroceryItems WHERE item = :item) > :quantity) " +
						"THEN (UPDATE GroceryItems SET item = :item, quantity = ((SELECT quantity FROM GroceryItems WHERE item = :item) - :quantity) WHERE item = :item)) " +
					"END;";

				NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//				cmd.Parameters.AddWithValue("@item", item);
//			    cmd.Parameters.AddWithValue("@quantity", quantity);
				cmd.Parameters.Add(new NpgsqlParameter("item", NpgsqlTypes.NpgsqlDbType.Text));
				cmd.Parameters[0].Value = item;
				cmd.Parameters.Add(new NpgsqlParameter("quantity", NpgsqlTypes.NpgsqlDbType.Integer));
				cmd.Parameters[1].Value = quantity;

				cmd.ExecuteNonQuery();
		    }

			conn.Close();

//			else
//		    {
//				string sql =
//					"DELETE :item AND :quantity" +
//					"FROM GroceryItem" +
//					"WHERE item=':item'";
//				NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//				cmd.Parameters.AddWithValue("@item", item);
//
//			    cmd.Parameters.AddWithValue("@quantity", quantity);
//				cmd.ExecuteNonQuery();
//		    }


		    //cmd.Connection = conn;
		    //cmd.CommandText = sql;
	    }
    }
}
