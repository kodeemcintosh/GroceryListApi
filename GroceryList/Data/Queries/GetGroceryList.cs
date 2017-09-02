using System.Collections.Generic;
using GroceryList.Data.Map;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class GetGroceryList
    {
	    private readonly IDataMapper _dataMapper;
	    public GetGroceryList(IDataMapper dataMapper)
	    {
		    _dataMapper = dataMapper;
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

	    public List<GroceryItem> GetGroceryListQuery()
	    {

			// Create and open database connection
			string connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
			var sql = "SELECT * FROM GroceryItems " +
				"ORDER BY last_modified ASC NULLS LAST;";
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

			// Execute Query
			NpgsqlDataReader dataReader = cmd.ExecuteReader();

			List<GroceryItem> groceryList = new List<GroceryItem>();

//			try
//			{
			groceryList = _dataMapper.GetGroceryItemsMapper(dataReader);
//			}
//			catch (NpgsqlException e)
//			{
//				Console.WriteLine(e);
//				throw;
//			}
//			finally
//			{
//				Console.WriteLine("Closing connections");
			conn.Close();
//			}

		    return groceryList;
	    }

	    public List<GroceryItem> GetGroceryListQuery(BaseRequest Request)
	    {

		    Request.sortField = Request.sortField ?? "last_modified";
		    Request.sortDirection = Request.sortDirection ?? "ASC";

			string connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
		    var sql = "SELECT * FROM GroceryItems " +
		              "WHERE 1 = 1 ";
//				  "ORDER BY :sortField ;";
//				":sortDirection NULLS LAST;";
//				"ORDER BY last_modified ASC;";
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//			cmd.Parameters.Add(new NpgsqlParameter("sortField", NpgsqlTypes.NpgsqlDbType.Text));
//		    cmd.Parameters[0].Value = Request.sortField.ToUpper();
//			cmd.Parameters.Add(new NpgsqlParameter("sortDirection", NpgsqlTypes.NpgsqlDbType.Text));
//		    cmd.Parameters[1].Value = Request.sortDirection.ToUpper();

			// Execute Query
			NpgsqlDataReader dataReader = cmd.ExecuteReader();

			List<GroceryItem> groceryList = new List<GroceryItem>();

//			try
//			{
			groceryList = _dataMapper.GetGroceryItemsMapper(dataReader);
//			}
//			catch (NpgsqlException e)
//			{
//				Console.WriteLine(e);
//				throw;
//			}
//			finally
//			{
//				Console.WriteLine("Closing connections");
			conn.Close();
//			}

		    return groceryList;
	    }
    }
}
